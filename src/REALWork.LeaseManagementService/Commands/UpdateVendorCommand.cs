using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateVendorCommand : IRequest<Unit>
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
    }
}
