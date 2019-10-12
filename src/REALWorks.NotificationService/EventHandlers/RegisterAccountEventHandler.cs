using REALWorks.MessagingServer.EventBus;
using REALWorks.NotificationService.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.EventHandlers
{
    public class RegisterAccountEventHandler : IIntegrationEventHandler<RegisterAccountEvent>
    {
        public Task Handle(RegisterAccountEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
