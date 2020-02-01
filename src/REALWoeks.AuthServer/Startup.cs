using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using REALWorks.AuthServer.Data;
using Microsoft.AspNetCore.Identity;
using REALWorks.AuthServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MediatR;
using Serilog;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using REALWorks.AuthServer.Services;
using REALWorks.MessagingServer.Messages;
using Swashbuckle.AspNetCore.Filters;

namespace REALWorks.AuthServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Application", "Authentication Service")
                //.WriteTo.Seq("http://localhost:5341") // temporarily disabled so that the logs written to log files in E:\Temp\real --- by default
                .CreateLogger();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                                                                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // add messagepublisher classes
            var configSection = Configuration.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];
            string exchange = configSection["Exchange"]; // Exchange1: publishing exchagne

            services.AddTransient<IMessagePublisher>((sp) => new RabbitMQMessagePublisher(host, userName, password, exchange));

            // Add asp.net identity
            services.AddIdentity<ApplicationUser, ApplicationRole>( config =>
                    {
                        config.SignIn.RequireConfirmedEmail = true;
                        config.User.RequireUniqueEmail = true;
                    }                
                )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


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
                }
             );

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddSingleton(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Authentication",
                    Description = "Authentication Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });

                c.AddSecurityDefinition("oauth2", new ApiKeyScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                c.OperationFilter<SecurityRequirementsOperationFilter>();

            });

            // CORS
            // Add service and create Policy with options 
            services.AddCors(options => {
          options.AddPolicy("CorsPolicy",
            b => b.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials());
        });
        
        services.AddMediatR(typeof(Startup));

        services.AddSingleton<IEmailSender, EmailSender>();

            //services.AddSingleton<RabbitListener>();

        services.AddMvc();

    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseDefaultFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marketing Management API V1");
                c.RoutePrefix = string.Empty;
            });

            loggerFactory.AddSerilog();

            app.UseCors("CorsPolicy");

            //loggerFactory.AddSerilog();

            app.UseMvc();


        }
    }
}
