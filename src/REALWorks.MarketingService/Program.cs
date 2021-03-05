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
using MongoDB.Driver;
using REALWorks.MarketingData;
using REALWorks.MessagingServer.Messages;

namespace REALWorks.MarketingService
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
            string exchange = configSection["Exchange"];
            string connName = configSection["ConnectionName"];

            // setup messagehandler
            RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler(host, userName, password, exchange, connName, "asset_created.marketing", "asset_created.#");  // subscribe/listen to queue 

            RabbitMQMessageHandler messageHandler2 = new RabbitMQMessageHandler(host, userName, password, exchange, connName, "lease_finalized.marketing", "lease_finalized.#");  // subscribe/listen to queue 


            // setup DBContext
            var sqlConnectionString = Config.GetConnectionString("AppDbConnection");
            var dbContextOptions = new DbContextOptionsBuilder<AppMarketingDbDataContext>()
                .UseSqlServer(sqlConnectionString)
                .Options;
            var dbContext = new AppMarketingDbDataContext(dbContextOptions);


            //var mongoConnectionString = Config.GetConnectionString("MongoDbConnection");
            //var mongoClient = new MongoClient(mongoConnectionString);
            //var mongoDb = mongoClient.GetDatabase("MessageDb");



            //Policy
            //    .Handle<Exception>()
            //    .WaitAndRetry(5, r => TimeSpan.FromSeconds(5), (ex, ts) => { Log.Error("Error connecting to DB. Retrying in 5 sec."); })
            //    .Execute(() => DBInitializer.Initialize(dbContext));

            // start event-handler
            EventHandlers.EventHandler eventHandler = new EventHandlers.EventHandler(messageHandler, dbContext);
            eventHandler.Start();

            EventHandlers.EventHandler eventHandler2 = new EventHandlers.EventHandler(messageHandler2, dbContext);
            eventHandler2.Start();

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
