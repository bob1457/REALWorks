using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services.MessageService
{
    public interface ISmsSender
    {
        Task<string> SendTextAsync(string from, string to, string message);
    }
}
