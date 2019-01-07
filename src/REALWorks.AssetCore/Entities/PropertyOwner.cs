using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class PropertyOwner: Entity
    {
        public PropertyOwner()
        {
            OwnerProperty = new HashSet<OwnerProperty>();
        }

        public PropertyOwner(string userName, 
            string firstName, 
            string lastName, 
            string contactEmail, 
            string contactTelephone1, 
            string contactTelephone2, 
            bool onlineAccess, 
            string userAvartaImgUrl, 
            bool? isActive, 
            int? roleId, 
            string notes, 
            ICollection<OwnerProperty> ownerProperty
            )
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            OnlineAccess = onlineAccess;
            UserAvartaImgUrl = userAvartaImgUrl;
            IsActive = isActive;
            RoleId = roleId;
            Notes = notes;
            OwnerProperty = ownerProperty;
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactTelephone1 { get; private set; }
        public string ContactTelephone2 { get; private set; }
        public bool OnlineAccess { get; private set; }
        public string UserAvartaImgUrl { get; private set; }
        public bool? IsActive { get; private set; }
        public int? RoleId { get; private set; }
        public string Notes { get; private set; }

        public ICollection<OwnerProperty> OwnerProperty { get; set; }
    }
}
