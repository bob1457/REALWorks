using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class WorkOrderListViewModel
    {
        public int Id { get; set; }
        public string WorkOrderName { get;  set; }        
        public string WorkOrderCategory { get;  set; }
        public int RentalPropertyId { get;  set; }
        public string RentalPropertyName { get; set; }
        public int VendorId { get;  set; }
        public string VendorName { get; set; }
        public string WorkOrderType { get;  set; }
        public DateTime? StartDate { get;  set; }
        public DateTime? EndDate { get;  set; }
        public bool IsEmergency { get;  set; }
        public string WorkOrderStatus { get;  set; }

    }
}
