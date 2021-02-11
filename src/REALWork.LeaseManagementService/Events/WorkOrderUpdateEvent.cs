using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Events
{
    public class WorkOrderUpdateEvent : INotification
    {
        public int ServiceRequestId { get; set; }
        public int WorkOrderid { get; set; }

    }
}
