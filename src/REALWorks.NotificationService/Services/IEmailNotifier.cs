using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services
{
    public interface IEmailNotifier
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
