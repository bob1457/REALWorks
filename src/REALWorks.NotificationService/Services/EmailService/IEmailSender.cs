﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services.EmailService
{
    public interface IEmailSender
    {
        Task<string> SendEmailAsync(string email, string subject, string message);
    }
}
