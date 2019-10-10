using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
//using MimeKit;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace REALWorks.AuthServer.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHostingEnvironment _env;

        public EmailSender(IOptions<EmailSettings> emailSettings, IHostingEnvironment env)
        {
            _emailSettings = emailSettings.Value;
            _env = env;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            //throw new NotImplementedException();

            try
            {
                //var mimeMessage = new MimeMessage();

                //mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Sender));

                //mimeMessage.To.Add(new MailboxAddress(email));

                //mimeMessage.Subject = subject;

                //mimeMessage.Body = new TextPart("html")
                //{
                //    Text = message
                //};

                using (var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort))
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    try 
                    {

                        MailMessage mail = new MailMessage() //;
                        {
                            From = new MailAddress(_emailSettings.SenderName)
                        };


                        mail.To.Add(new MailAddress(email)); // "bob.yuan@yahoo.com"
                        mail.Subject = subject; // "Test via gamil smtp";
                        mail.Body = message; //"Test......";
                        mail.IsBodyHtml = true;

                        // The third parameter is useSSL (true if the client should make an SSL-wrapped
                        // connection to the server; otherwise, false).
                        //await client.ConnectAsync(_emailSettings.MailServer, _emailSettings.MailPort, true); 
                        //await client.ConnectAsync("in-v3.mailjet.com", 25, false);

                        client.Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);
                        client.EnableSsl = true;
                        await client.SendMailAsync(mail);

                        //await client.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);

                        //await client.SendAsync(mimeMessage);

                        //await client.DisconnectAsync(true);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    // Note: only needed if the SMTP server requires authentication
                    
                }

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
