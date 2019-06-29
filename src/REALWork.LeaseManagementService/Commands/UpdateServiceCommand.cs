using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using static REALWork.LeaseManagementCore.Entities.ServiceRequest;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateServiceCommand : IRequest<Unit>
    {
        public int ServiceRequestId { get; set; }
        public int Status { get; set; }
        public int WorkOrderId { get; set; }
    }
}
