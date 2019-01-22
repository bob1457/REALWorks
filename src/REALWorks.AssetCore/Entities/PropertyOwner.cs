using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class PropertyOwner: Entity, IAggeregate
    {
        private PropertyOwner()
        {
            //OwnerProperty = new HashSet<OwnerProperty>();
        }

        public PropertyOwner(
            string userName, 
            string firstName, 
            string lastName, 
            string contactEmail, 
            string contactTelephone1, 
            string contactTelephone2, 
            bool onlineAccess, 
            string userAvartaImgUrl, 
            bool isActive, 
            int roleId, 
            string notes, 
            DateTime createdOn,
            DateTime updatedOn
            //ICollection<OwnerProperty> ownerProperty
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
            Created = createdOn;
            Modified = updatedOn;
            //OwnerProperty = ownerProperty;
        }

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

        public List<OwnerProperty> OwnerProperty { get; private set; } = new List<OwnerProperty>();


        public void Update(/*PropertyOwner owner,*/ string firstName, string lastName, string email, 
            string telephone1, string telephone2, string avatarUrl, bool isActive, 
            string notes)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = email;
            ContactTelephone1 = telephone1;
            ContactTelephone2 = telephone2;            
            UserAvartaImgUrl = avatarUrl;
            IsActive = isActive;
            Notes = notes;
            Modified = DateTime.Now;

            //return owner;
        }

        public void Deactivate() // Deactivate/soft delete owner
        {
            // TO DO

        }

        public void ConfigOnlineAccess() // Enable/disable online owner access
        {
            // TO DO

        }
    }
}
