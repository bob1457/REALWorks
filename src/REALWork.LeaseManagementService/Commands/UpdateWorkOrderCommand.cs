using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateWorkOrderCommand : IRequest<Unit>
    {
        public int WorkOrderId { get; set; }
        public string WorkOrderDetails { get;  set; }
        public string WorkOrderCategory { get;  set; }
                
        public string WorkOrderType { get;  set; }
        
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        
        public string WorkOrderStatus { get;  set; }
        
        public string Note { get;  set; }
    }
}
