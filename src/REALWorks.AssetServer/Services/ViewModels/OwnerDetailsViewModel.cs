using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class OwnerDetailsViewModel
    {
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactTelephone1 { get; private set; }
        public string ContactTelephone2 { get; private set; }
        public bool OnlineAccess { get; private set; }
        public string UserAvartaImgUrl { get; private set; }
        public bool IsActive { get; private set; }
        public int RoleId { get; private set; }
        public string Notes { get; private set; }

        //public string StreetNUmber { get; set; }
        //public string City { get; set; }
        //public string StateProvince { get; set; }
        //public string ZipPostCode { get; set; }
        //public string Country { get; set; }

        public List<OwnerProperty> OwnerProperty { get; private set; } = new List<OwnerProperty>();

    }
}
