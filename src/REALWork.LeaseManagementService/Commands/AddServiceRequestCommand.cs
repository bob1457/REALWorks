using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWork.LeaseManagementCore.Entities.ServiceRequest;

namespace REALWork.LeaseManagementService.Commands
{
    public class AddServiceRequestCommand: IRequest<ServiceRequest>
    {
        public string RequestSubject { get; set; }
        public string ServiceCategory { get; set; }
        public string RequestDetails { get; set; }
        public UrgencyLevel Urgent { get; set; }
        public RequestStatus Status { get; set; }
        public int LeaseId { get; set; }
        public int RequestorId { get; set; }
        public int WorkOrderId { get; set; }
        public string Notes { get; set; }
    }
}
