using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using REALWork.LeaseManagementData;
using REALWorks.MessagingServer.Messages;
using Serilog;

namespace REALWork.LeaseManagementService
{
    public class Program
    {
        public static IConfigurationRoot Config { get; private set; }

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
            Startup();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void Startup(/*[FromServices] UserManager<ApplicationUser> _userManager*/)
        {
            // setup RabbitMQ
            var configSection = Config.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];
            string exchange = configSection["Exchange"]; // Exchagne2: listening exchange
            string connName = configSection["ConnectionName"];

            // setup messagehandler
            RabbitMQMessageHandler messageHandlerMarketing = new RabbitMQMessageHandler(host, userName, password, exchange, connName, "app_approved", "app_approved.#"); // "real", ""); listening queue: marketing.lease, 
            RabbitMQMessageHandler messageHandlerAsset = new RabbitMQMessageHandler(host, userName, password, exchange, connName, "asset_created.lease", "asset_created.#");


            //setup DBContext
            //
            var sqlConnectionString = Config.GetConnectionString("AppDbConnection");
            var dbContextOptions = new DbContextOptionsBuilder<AppLeaseManagementDbContext>()
                .UseSqlServer(sqlConnectionString)
                .Options;
            var dbContext = new AppLeaseManagementDbContext(dbContextOptions);





            //Policy
            //    .Handle<Exception>()
            //    .WaitAndRetry(5, r => TimeSpan.FromSeconds(5), (ex, ts) => { Log.Error("Error connecting to DB. Retrying in 5 sec."); })
            //    .Execute(() => DBInitializer.Initialize(dbContext));

            // start event-handler
            //
            EventHandlers.EventHandler eventHandlerMarketing = new EventHandlers.EventHandler(messageHandlerMarketing, dbContext); // Subscribe/Handle message publshied by Marketing Service
            eventHandlerMarketing.Start();

            EventHandlers.EventHandler eventHandlerAsset = new EventHandlers.EventHandler(messageHandlerAsset, dbContext); // Subscribe/Handle message publshied by Asset Service
            eventHandlerAsset.Start();

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



        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
