using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class PropertyOwner
    {
        public PropertyOwner()
        {
            OwnerProperty = new HashSet<OwnerProperty>();
        }

        public int PropertyOwnerId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public bool? IsActive { get; set; }
        public int? RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<OwnerProperty> OwnerProperty { get; set; }
    }
}
