using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class OwnerListByPropertyViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public bool OnlineAccess { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string Notes { get; set; }
    }
}
