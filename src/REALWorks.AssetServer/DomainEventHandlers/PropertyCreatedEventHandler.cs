using MediatR;
using REALWorks.AssetCore.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.DomainEventHandlers
{
    public class PropertyCreatedEventHandler : INotificationHandler<PropertyCreatedEvent>
    {

        public Task Handle(PropertyCreatedEvent notification, CancellationToken cancellationToken)
        {
            Log.Information("Property with id {PropertyId} has been successfully created.", notification.Property.Id);

            return Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
