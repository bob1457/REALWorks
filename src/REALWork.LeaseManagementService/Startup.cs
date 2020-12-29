using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.EventHandlers;
using REALWork.LeaseManagementService.Events;
using REALWorks.InfrastructureServer.ServiceDiscovery;
using REALWorks.MessagingServer.EventBus;
using REALWorks.MessagingServer.EventBusRabbitMQ;
using REALWorks.MessagingServer.Messages;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace REALWork.LeaseManagementService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                //.WriteTo.Seq("http://localhost:5341") // temporarily disabled so that the logs written to log files in E:\Temp\real --- by default
                .CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            string dbConnectionString = Configuration.GetConnectionString("AppDbConnection"); // DB: REALAsset2

            services.AddDbContext<AppLeaseManagementDbContext>(options =>
                     options.UseSqlServer(dbConnectionString, builder => builder.MigrationsAssembly("REALWork.LeaseManagementData")));

            // add messagepublisher classes
            var configSection = Configuration.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];
            string exchange = configSection["Exchange"];
            //string retries = configSection["retries"];

            services.AddTransient<IMessagePublisher>((sp) => new RabbitMQMessagePublisher(host, userName, password, exchange)); // "realworks"));

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

            ConfigureConsul(services); // Consul service discovery

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Lease Management",
                    Description = "Lease Management Web API",
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

            #region *************FOR FUTURE IMPLEMENTATION ***********************
            /*
            // Make connexction to rabbitmq server
            //
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    //HostName = Configuration["EventBusConnection"]
                    HostName = host// configSection["Host"]
                };

                if (!string.IsNullOrEmpty(configSection["UserName"]))
                {
                    //factory.UserName = Configuration["EventBusUserName"];
                    factory.UserName = userName; //configSection["UserName"];

                }

                if (!string.IsNullOrEmpty(configSection["Password"]))
                {
                    //factory.Password = Configuration["EventBusPassword"];
                    factory.Password = password;// Configuration["Password"];
                }

                //var retryCount = 5;
                //if (!string.IsNullOrEmpty(configSection["retires"]))
                //{
                //    retryCount = int.Parse(retries);// int.Parse(Configuration["EventBusRetryCount"]);
                //}

                return new DefaultRabbitMQPersistentConnection(factory, logger, int.Parse(retries));
            });
*/
            #endregion
            //RegisterEventBus(services, int.Parse(retries)); // *************FOR FUTURE IMPLEMENTATION ***********************

            services.AddMvc()//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddOptions();            

            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());

        }

        #region *************FOR FUTURE IMPLEMENTATION ***********************
        private void RegisterEventBus(IServiceCollection services, int retry)
        {
            var subscriptionClientName = Configuration["SubscriptionClientName"]; // queue name

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                //var retryCount = 5;
                //if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                //{
                //    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                //}

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retry);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
        }
        #endregion

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication(); // it should be here
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lease Management API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();

            loggerFactory.AddSerilog();

            app.UseCors("CorsPolicy");

            app.UseMvc();

            //ConfigureEventBus(app); // FOR FUTURE IMPLEMENTATION
        }
        

        // *************FOR FUTURE IMPLEMENTATION ***********************
        //
        //private void ConfigureEventBus(IApplicationBuilder app)
        //{
        //    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

        //    eventBus.Subscribe<NewTemantCreatedEvent, NewTemantCreatedEventHandler>();

        //}
    }
}
