using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using REALWorks.MessagingServer.Messages;
using REALWorks.AuthServer.EventHandlers;
using REALWorks.AuthServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using REALWorks.AuthServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace REALWorks.AuthServer
{
    public class Program
    {
        public static IConfigurationRoot Config { get; private set; }

        private readonly UserManager<ApplicationUser> _userManager;

        static Program()
        {
            Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                //.AddJsonFile($"appsettings.{_env}.json", optional: false)
                .Build();
        }

        public static void Main(string[] args)
        {
            //Startup();
            BuildWebHost(args).Run();
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        
        private static void Startup(/*[FromServices] UserManager<ApplicationUser> _userManager*/)
        {
            
            // setup RabbitMQ
            var configSection = Config.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];

            // setup messagehandler
            //RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler(host, userName, password, "", "realworks", "real", "");

            // setup DBContext
            var sqlConnectionString = Config.GetConnectionString("DefaultConnection");
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(sqlConnectionString)
                .Options;
            var dbContext = new ApplicationDbContext(dbContextOptions);


            


            //Policy
            //    .Handle<Exception>()
            //    .WaitAndRetry(5, r => TimeSpan.FromSeconds(5), (ex, ts) => { Log.Error("Error connecting to DB. Retrying in 5 sec."); })
            //    .Execute(() => DBInitializer.Initialize(dbContext));

            // start event-handler
            //EventHandlers.EventHandler eventHandler = new EventHandlers.EventHandler(messageHandler, dbContext, null );
            //eventHandler.Start();

            //if (_env == "Development")
            //{
            //    Log.Information("WorkshopManagement Eventhandler started.");
            //    Console.WriteLine("Press any key to stop...");
            //    Console.ReadKey(true);
            //    eventHandler.Stop();
            //}
            //else
            //{
            //    Log.Information("WorkshopManagement Eventhandler started.");
            //    while (true)
            //    {
            //        Thread.Sleep(10000);
            //    }
            //}
        }

    }
}
