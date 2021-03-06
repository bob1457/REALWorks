﻿using System;
using System.Configuration;
using System.Text;
using Autofac;
using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using REALWorks.AssetData;
using REALWorks.AssetServer.EventHandlers;
using REALWorks.AssetServer.Events;
using REALWorks.AssetServer.Infrastructure;
using REALWorks.InfrastructureServer.MessageLog;
using REALWorks.MessagingServer.EventBus;
using REALWorks.MessagingServer.EventBusRabbitMQ;
using REALWorks.MessagingServer.Messages;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using Consul;
using REALWorks.InfrastructureServer.ServiceDiscovery;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using HealthChecks.RabbitMQ;

namespace REALWorks.AssetServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Application", "Asset Management Service")
                .WriteTo.Seq("http://localhost:5341") // temporarily disabled so that the logs written to log files in E:\Temp\real --- by default
                .CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string dbConnectionString = Configuration.GetConnectionString("AppDbConnection"); // DB: REALAsset

            services.AddDbContext<AppDataBaseContext>(options =>
                     options.UseSqlServer(dbConnectionString, builder => builder.MigrationsAssembly("REALWorks.AssetData")));

            // add messagepublisher classes
            var configSection = Configuration.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string port = configSection["Port"];
            string password = configSection["Password"];
            string exchange = configSection["Exchange"];

            //var consulConfigSection = Configuration.GetSection("ServiceConfig");
            //string serviceName = consulConfigSection["ServiceConfig:serviceName"];
            //string serviceId = consulConfigSection["serviceId"];
            //string serviceAddress = consulConfigSection["serviceDiscoveryAddress"];

            services.AddTransient<IMessagePublisher>((sp) => new RabbitMQMessagePublisher(host, userName, password, exchange)); // "realworks"));

            services.Configure<Settings>(
            options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDB:Database").Value;
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddCookie()
            .AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"]))
                };
            });

            //services.Configure<ConsulConfig>(Configuration.GetSection("Consul"));
            //services.AddSingleton<IConsulClient, ConsulClient>(p =>
            //{
            //    var address = Configuration["Consul:Adress"];
            //    Con 
            //});



            ConfigureConsul(services);

            services.AddTransient<IMessageLoggingService, MessageLoggingService>();
            services.AddTransient<IMessageContext, MessageContext>();

            // Registers health check services
            services.AddHealthChecks()
                .AddRabbitMQ(
                    $"amqp://{userName}:{password}@{host}:{port}",                   // {Configuration["RabbitMQ"]
                    name: "Asset service message queue",
                    tags: new string[] { "rabbitmqbus" }
                )
                .AddCheck("Database", new SqlConnectionHealthCheck(Configuration["ConnectionStrings:AppDbConnection3"]))
                //.AddCheck("Message Queue", new RabbitMQHealthCheck("host=localhost; username = guest; password = guest"))
                ;
           
            services.AddHealthChecksUI();

            /*

                        services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
                        {
                            var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                            var factory = new ConnectionFactory()
                            {
                                HostName = Configuration["EventBusConnection"]
                            };

                            if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                            {
                                factory.UserName = Configuration["EventBusUserName"];
                            }

                            if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                            {
                                factory.Password = Configuration["EventBusPassword"];
                            }

                            var retryCount = 5;
                            if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                            {
                                retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                            }

                            return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
                        });
            */
            //RegisterEventBus(services); // diasbled for further investigation

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Asset Management",
                    Description = "Asset Management Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });
            });

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                  b => b.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials());
            });

            services.AddMediatR(typeof(Startup));

            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter>();

            services.AddAutoMapper();
            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 

            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        }

        private void ConsulConfig(ConsulClientConfiguration config)
        {
            //throw new NotImplementedException();
            config.Address = new Uri("http://localhost:8500"); //63899
            config.Datacenter = "dc1";
        }

        // Register Consul Service
        //
        private void ConfigureConsul(IServiceCollection services)
        {
            //throw new NotImplementedException();

            //var serviceConfig = Configuration.GetServiceConfig();

            var serviceConfig = new ServiceConfig
            {
                ServiceDiscoveryAddress = Configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress"),
                ServiceAddress = Configuration.GetValue<Uri>("ServiceConfig:serviceAddress"),
                ServiceName = Configuration.GetValue<string>("ServiceConfig:serviceName"),
                ServiceId = Configuration.GetValue<string>("ServiceConfig:serviceId")
            };

            //serviceConfig.ServiceDiscoveryAddress = (Uri)Configuration.GetSection("serviceDiscoveryAddress");
            //serviceConfig.ServiceAddress = (Uri)Configuration.GetSection("serviceAddress");
            //serviceConfig.ServiceId = Configuration.GetSection("serviceId").ToString();
            //serviceConfig.ServiceName = Configuration.GetSection("serviceName").ToString();

            services.RegisterConsulServices(serviceConfig);

        }

        #region TO DO MORE INVESTIGATION
        /*
        private void RegisterEventBus(IServiceCollection services)
        {
            var subscriptionClientName = Configuration["SubscriptionClientName"];

            
                services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                {
                    var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                    var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                    var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                    var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                    var retryCount = 5;
                    if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                    {
                        retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                    }

                    return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
                });
            

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            services.AddTransient<TestIntegrationEventHandler>();
            //services.AddTransient<OrderStartedIntegrationEventHandler>();



            //throw new NotImplementedException();
        }
        */
        #endregion

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {

            var consulConfigSection = Configuration.GetSection("ServiceConfig");
            string serviceName = consulConfigSection["serviceName"];
            string serviceId = consulConfigSection["serviceId"];
            string serviceAddress = consulConfigSection["serviceDiscoveryAddress"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication(); // it should be here
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asset Management API V1");
                c.RoutePrefix = string.Empty;
            });

            //var serviceConfig = new ServiceConfig
            //{
            //    ServiceDiscoveryAddress = Configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress"),
            //    ServiceAddress = Configuration.GetValue<Uri>("ServiceConfig:serviceAddress"),
            //    ServiceName = Configuration.GetValue<string>("ServiceConfig:serviceName"),
            //    ServiceId = Configuration.GetValue<string>("ServiceConfig:serviceId")
            //};

            


            app.UseHttpsRedirection();

            //ConfigureEventBus(app); // diasbled for further investigation

            loggerFactory.AddSerilog();

            app.UseCors("CorsPolicy");

            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

            app.UseMvc();
        
            /**/
            #region Consul Registration/Deregistration

            //using (var client = new ConsulClient(ConsulConfig))
            //{
            //    client.Agent.ServiceRegister(new AgentServiceRegistration()
            //    {
            //        ID = serviceId,
            //        Address = serviceAddress,
            //        Name = serviceName //,
            //        //Check = new AgentServiceCheck
            //        //{
            //        //    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5)
            //        //    // Health Check
            //        //}
            //    }).Wait();
            //}

            applicationLifetime.ApplicationStopping.Register(() =>
                {
                    using(var client = new ConsulClient(ConsulConfig))
                    {
                        client.Agent.ServiceDeregister(Configuration.GetValue<string>("ServiceConfig:serviceId")).Wait(); /*serviceId*/
                    }
                }
            );

        }

        private void ServiceConfig(ConsulClientConfiguration c)
        {
            //throw new NotImplementedException();
            c.Address = Configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress");
            
        }

        #endregion  


        // Custom health check

        public static IServiceCollection AddCustomHealthCheck(IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddSqlServer(
                    configuration["AppDbConnection3"],
                    name: "AssetDB-check",
                    tags: new string[] { "assetDb" });

            hcBuilder.AddRabbitMQ(
                $"amqp://{configuration["RabbitMQ"]}",
                name: "Asset service message-queue check",
                tags: new string[] {"rabbitmq"});




            //services.AddDbContext<CatalogContext>(options =>
            //{
            //    options.UseSqlServer(configuration["ConnectionString"],
            //                         sqlServerOptionsAction: sqlOptions =>
            //                         {
            //                             sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
            //                             //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
            //                             sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            //                         });

            //    // Changing default behavior when client evaluation occurs to throw. 
            //    // Default in EF Core would be to log a warning when client evaluation is performed.
            //    options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            //    //Check Client vs. Server evaluation: https://docs.microsoft.com/en-us/ef/core/querying/client-eval
            //});



            return services;
        }


        #region TO DO MORE INVESTIGATION
        /*
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<TestIntegrationEvent, TestIntegrationEventHandler>();

            //throw new NotImplementedException();
        }
        */
        #endregion

    }
    }
