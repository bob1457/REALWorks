using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class VendorDetailsViewModel
    {
        public int Id { get; set; }
        public string VendorBusinessName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string VendorDesc { get; private set; }
        public string VendorSpecialty { get; private set; }
        public string VendorContactTelephone1 { get; private set; }
        public string VendorContactOthers { get; private set; }
        public string VendorContactEmail { get; private set; }
        public bool IsActive { get; private set; }        
        public bool OnlineAccessEnbaled { get; private set; }
        public string UserAvartaImgUrl { get; private set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public IList<WorkOrder> WrokOrderList { get; set; }
    }
}
