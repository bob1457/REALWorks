using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consul;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using REALWorks.InfrastructureServer.ServiceDiscovery;
using REALWorks.MarketingData;
using REALWorks.MessagingServer.Messages;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace REALWorks.MarketingService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {            
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                //.WriteTo.Seq("http://localhost:5341") // temporarily disabled so that the logs written to log files in E:\Temp\real --- by default
                .CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string dbConnectionString = Configuration.GetConnectionString("AppDbConnection");

            services.AddDbContext<AppMarketingDbDataContext>(options =>
                     options.UseSqlServer(dbConnectionString, builder => builder.MigrationsAssembly("REALWorks.MarketingData")));


            // add messagepublisher classes
            var configSection = Configuration.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];
            string exchange = configSection["Exchange"]; // Exchange1: publishing exchagne

            services.AddTransient<IMessagePublisher>((sp) => new RabbitMQMessagePublisher(host, userName, password, exchange));// "realworks"));


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

            ConfigureConsul(services);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Marketing Management",
                    Description = "Marketing Management Web API",
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

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc()
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketing Management API V1");
                c.RoutePrefix = string.Empty;
            });

            loggerFactory.AddSerilog();

            app.UseCors("CorsPolicy");

            app.UseMvc();

            #region Consul Registration/Deregistration

            //using (var client = new ConsulClient(ConsulConfig))
            //{
            //    client.Agent.ServiceRegister(new AgentServiceRegistration()
            //    {
            //        ID = serviceId,
            //        Address = "http://localhost",  //serviceAddress,
            //        Port = 63899,
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
                using (var client = new ConsulClient(ConsulConfig))
                {
                    client.Agent.ServiceDeregister(Configuration.GetValue<string>("ServiceConfig:serviceId")).Wait(); /*serviceId*/
                }
            });
        }

        private void ServiceConfig(ConsulClientConfiguration c)
        {
            //throw new NotImplementedException();
            c.Address = Configuration.GetValue<Uri>("ServiceConfig:serviceDiscoveryAddress");

        }

        private void ConsulConfig(ConsulClientConfiguration config)
        {
            //throw new NotImplementedException();
            config.Address = new Uri("http://localhost:8500");
            config.Datacenter = "dc1";
        }

        #endregion
    }
}
