using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class WorkOrderDetailsViewModel
    {
        public string WorkOrderName { get;  set; }
        public string WorkOrderDetails { get;  set; }
        public string WorkOrderCategory { get;  set; }
        public int RentalPropertyId { get;  set; }
        public int VendorId { get;  set; }
        public string WorkOrderType { get;  set; }
        //public decimal InvoiceAmount { get;  set; }
        //public string InvoiceDocUrl { get;  set; }
        //public DateTime InvoiceDate { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public bool IsOwnerAuthorized { get;  set; }
        public bool IsEmergency { get;  set; }
        public string WorkOrderStatus { get;  set; }
        //public bool IsPaid { get;  set; }
        //public DateTime PaymentDate { get;  set; }
        //public string PaymentMethod { get;  set; }
        //public decimal? PaymentAmount { get;  set; }        
        public string Note { get;  set; }

        public RentalProperty RentalProperty { get;  set; }
        public Invoice Invoice { get;  set; }
        public Vendor Vendor { get;  set; }
    }
}
