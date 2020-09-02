using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class AddVendorCommand: IRequest<Vendor>
    {
        public string UserName { get;  set; }
        public string VendorBusinessName { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string VendorDesc { get;  set; }
        public string VendorSpecialty { get;  set; }
        public string VendorContactTelephone1 { get;  set; }
        public string VendorContactOthers { get;  set; }
        public string VendorContactEmail { get;  set; }
        public bool IsActive { get;  set; }
        public int RoleId { get;  set; }
        public bool OnlineAccessEnbaled { get;  set; }
        public string UserAvartaImgUrl { get;  set; }
    }
}
