using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class AllOwnerListViewMode
    {       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }        
        public bool OnlineAccess { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public bool IsActive { get; set; }        
        public string StreetNumber { get; set; }        
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string ZipPostCode { get; set; }

    }
}
