using REALWork.LeaseManagementService.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Threading;

namespace REALWork.LeaseManagementService.DomainEventHandlers
{
    public class WorkOrderUpdateEventHandler : INotificationHandler<WorkOrderUpdateEvent>
    {
        public Task Handle(WorkOrderUpdateEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
