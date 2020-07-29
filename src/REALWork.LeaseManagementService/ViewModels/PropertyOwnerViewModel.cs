using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.ViewModels
{
    public class PropertyOwnerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactOther { get; set; }
        public int RentalPropertyId { get; set; }
        public string UserName { get; set; }

        public string OwnerStreetNum { get; set; }
        public string OwnerCity { get; set; }
        public string OwnerStateProvinc { get; set; }
        public string OwnerZipPostCode { get; set; }
        public string OwnerCountry { get; set; }
    }
}
