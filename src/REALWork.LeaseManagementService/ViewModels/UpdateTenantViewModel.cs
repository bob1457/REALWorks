using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class UpdateTenantViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public string ContactOthers { get; set; }
        public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public int LeaseId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }

        public RentalProperty RentalProperty { get; set; }

        public Lease Lease { get; set; }
    }
}
