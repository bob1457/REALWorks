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

        public PropertyOwner(//int ownerId,
                             string firstName,
                             string lastName,
                             string contactEmail,
                             string contactTelephone1,
                             string contactTelephone2,
                             bool onlineAccessEnbaled
            )
        {
            //PropertyOwnerId = ownerId;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            OnlineAccessEnbaled = onlineAccessEnbaled;
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
