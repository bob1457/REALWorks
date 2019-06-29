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

namespace REALWorks.NotificationService
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
            //Startup();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void Startup(/*[FromServices] UserManager<ApplicationUser> _userManager*/)
        {
            // setup RabbitMQ
            var mgConfigSection = Config.GetSection("RabbitMQ");
            string host = mgConfigSection["Host"];
            string userName = mgConfigSection["UserName"];
            string password = mgConfigSection["Password"];
            string exchange = mgConfigSection["Exchange2"]; // Exchagne2: listening exchange

            // setup messagehandler
            RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler(host, userName, password, exchange, "", "marketing", ""); // "real", ""); listening queue: marketing, publishing queue: asset

            // setup Email
            var emailConfigSection = Config.GetSection("Email");
            string smtpHost = emailConfigSection["Host"];
            string accountUserName = emailConfigSection["User"];
            string accountPassword = emailConfigSection["Pwd"];

            // setup SMS
            var smsConfigSection = Config.GetSection("SMS");
            //string smsHost = smsConfigSection["Host"];
            string accountName = smsConfigSection["Account"];
            string accountToken = smsConfigSection["Token"];



            // setup DBContext - MongoDB - TO DO ***********************************************************************
            //

            //var sqlConnectionString = Config.GetConnectionString("AppDbConnection3");
            //var dbContextOptions = new DbContextOptionsBuilder<AppDataBaseContext>()
            //    .UseSqlServer(sqlConnectionString)
            //    .Options;
            //var dbContext = new AppDataBaseContext(dbContextOptions);





            //Policy
            //    .Handle<Exception>()
            //    .WaitAndRetry(5, r => TimeSpan.FromSeconds(5), (ex, ts) => { Log.Error("Error connecting to DB. Retrying in 5 sec."); })
            //    .Execute(() => DBInitializer.Initialize(dbContext));

            // start event-handler - TO DO ***********************************************************************
            //
            //EventHandlers.EventHandler eventHandler = new EventHandlers.EventHandler(messageHandler, dbContext);
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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
