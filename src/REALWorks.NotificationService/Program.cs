using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using REALWorks.MessagingServer.Messages;
using REALWorks.NotificationService.Services.EmailService;
using REALWorks.NotificationService.EventHandlers;
using EventHandler = REALWorks.NotificationService.EventHandlers.EventHandler;
using REALWorks.NotificationService.Services.MessageService;
using Twilio.Clients;

namespace REALWorks.NotificationService
{
    public class Program
    {
        /**/
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

            var mailConfigSection = Config.GetSection("EmailSettings");
            string mailHost = mailConfigSection["MailServer"];
            int mailPort = Convert.ToInt32(mailConfigSection["MailPort"]);
            string mailUserName = mailConfigSection["Sender"];
            string mailSenderName = mailConfigSection["SenderName"];
            string mailPassword = mailConfigSection["Password"];
            //ISMTPMailSender smtpMailServer = new SMTPMailSender(mailHost, mailPort, mailUserName, mailPassword, mailSenderName); // original

            var smsConfiguration = Config.GetSection("SmsSettings");
            string accountSid = smsConfiguration["AccountSID"];
            string authCode = smsConfiguration["AuthToken"];


            EmailSettings settings = new EmailSettings(mailHost, mailPort, mailSenderName, mailUserName, mailPassword);
            IEmailSender smtpMailServer = new EmailSender(settings);

            SmsSettings smsSettings = new SmsSettings(accountSid, authCode);
            ISmsSender smsSender = new TextSender(smsSettings);
            //ITwilioRestClient smsSender = new SmsSender();

            //var emailSender = new EmailSender();
            //var emailSettings = new EmailSettings();

            // setup messagehandler
            RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler(host, userName, password, exchange, connName, "notification", "notification.#");
            // ABOVE: subscribe/listen to queue - queue name to be updated

            //IEmailSender emailSender = null;
            EventHandlers.EventHandler eventHandler = new EventHandlers.EventHandler(messageHandler, smtpMailServer, smsSender); //, dbContext);
            //EventHandler eventHandler = new EventHandler(messageHandler, smtpMailServer);

            //EmailNotificationEventHandler eventHandler = new EmailNotificationEventHandler(messageHandler, smtpMailServer); // original
            eventHandler.Start();

        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
            //.ConfigureAppConfiguration(configHost =>
            //{
            //    configHost.AddJsonFile("hostsettings.json", optional: true);
            //    configHost.AddJsonFile($"appsettings.json", optional: false);
            //})
            //.ConfigureServices((hostContext, services) =>
            //{
            //    services.AddTransient<IMessageHandler>((svc) =>
            //    {
            //        // setup RabbitMQ
            //        var configSection = Config.GetSection("RabbitMQ");
            //        string host = configSection["Host"];
            //        string userName = configSection["UserName"];
            //        string password = configSection["Password"];
            //        string exchange = configSection["Exchange"];
            //        string connName = configSection["ConnectionName"];
            //        return new RabbitMQMessageHandler(host, userName, password, exchange, connName, "notification", "notification.#");
            //        //RabbitMQMessageHandler messageHandler = new RabbitMQMessageHandler(host, userName, password, exchange, connName, "notification", "notification.#");
            //        //NotificationEventHandler handler = new NotificationEventHandler(messageHandler, )
            //        //return messageHandler;
            //    });

            //    services.AddTransient<ISMTPMailSender>((svc) =>
            //    {
            //        var mailConfigSection = hostContext.Configuration.GetSection("EmailSettings");
            //        string mailHost = mailConfigSection["MailServer"];
            //        int mailPort = Convert.ToInt32(mailConfigSection["MailPort"]);
            //        string mailUserName = mailConfigSection["Sender"];
            //        string mailPassword = mailConfigSection["Password"];
            //        return new SMTPMailSender(mailHost, mailPort, mailUserName, mailPassword);
            //    });

            //    services.AddTransient<NotificationEventHandler>();
            //})
            .UseStartup<Startup>();





    }
}
