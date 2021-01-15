using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class VendorUpdateResultViewModel
    {
        public int Id { get; set; }
        public string VendorBusinessName { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string VendorDesc { get;  set; }
        public string VendorSpecialty { get;  set; }
        public string VendorContactTelephone1 { get;  set; }
        public string VendorContactOthers { get;  set; }
        public string VendorContactEmail { get;  set; }
        public bool IsActive { get;  set; }
        public bool OnlineAccessEnbaled { get;  set; }
        public string UserAvartaImgUrl { get;  set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public IList<WorkOrder> WrokOrderList { get; set; }
    }
}
