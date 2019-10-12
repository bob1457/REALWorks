using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services.EmailService
{
    public interface ISMTPMailSender
    { 
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
