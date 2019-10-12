using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using REALWorks.MessagingServer.Messages;
using REALWorks.NotificationService.Services.EmailService;

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
            Startup();
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void Startup()
        {
            // setup RabbitMQ
            var configSection = Config.GetSection("RabbitMQ");
            string host = configSection["Host"];
            string userName = configSection["UserName"];
            string password = configSection["Password"];
            string exchange = configSection["Exchange"];
            string connName = configSection["ConnectionName"];

            //var emailSender = new EmailSender();
            var emailSettings = new EmailSettings();

            // setup messagehandler
            RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler(host, userName, password, exchange, connName, "notification", "notification.#");
            // ABOVE: subscribe/listen to queue - queue name to be updated

            IEmailSender emailSender = null;
            EventHandlers.EventHandler eventHandler = new EventHandlers.EventHandler(messageHandler, emailSender); //, dbContext);
            eventHandler.Start();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
