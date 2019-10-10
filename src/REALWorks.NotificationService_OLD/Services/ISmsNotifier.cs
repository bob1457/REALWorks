using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services
{
    public interface ISmsNotifier
    {
        Task SendSmsAsync(string to, string from, string body);
    }
}
