using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class AddWorkOrderCommand : IRequest<WorkOrderListViewModel>
    {
        public string WorkOrderName { get;  set; }
        public string WorkOrderDetails { get;  set; }
        public string WorkOrderCategory { get;  set; }
        public int RentalPropertyId { get;  set; }
        public int VendorId { get;  set; }
        public string WorkOrderType { get;  set; }        
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public bool IsOwnerAuthorized { get;  set; }
        public bool IsEmergency { get;  set; }
        public string WorkOrderStatus { get;  set; }        
        public string Note { get;  set; }

        public int ServiceRequestId { get; set; }
    }
}
