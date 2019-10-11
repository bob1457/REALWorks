using MediatR;
using REALWorks.AuthServer.Models.DomainEvents;
using REALWorks.AuthServer.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Models.DomainEventHandlers
{
    public class AccountRegistrationEventHandler : INotificationHandler<AccountRegistrationEvent>
    {
        private readonly IEmailSender _emailSender;

        public AccountRegistrationEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task Handle(AccountRegistrationEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                _emailSender.SendEmailAsync(notification.EmailRecipient, notification.EmailSubject, notification.EmailBody);

                Log.Information("Account registration notification has been sent to {Recipient} successfully", notification.EmailRecipient);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Error while sending notification to {Recipient}", notification.EmailRecipient);
            }
             

            return Unit.Task;

            //throw new NotImplementedException();
        }

    }
}
