using REALWorks.MarketingCore.Base;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class RentalPropertyOwner : Entity
    {
        private RentalPropertyOwner()
        {
        }

        public RentalPropertyOwner(string firstName, string lastName, string contactEmail, 
            string contactTelephone, string contactOther, OwnerAddress ownerAddress, DateTime create, DateTime updated)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone = contactTelephone;
            ContactOther = contactOther;
            OwnerAddress = ownerAddress;
            Created = create;
            Modified = updated;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactTelephone { get; private set; }
        public string ContactOther { get; private set; }
        public int RentalPropertyId { get; private set; }
        //public int RentalPropertyId { get; set; }
        //public bool OnlineAccess { get; private set; }
        //public string UserAvartaImgUrl { get; private set; }
        //public bool IsActive { get; private set; }
        //public int RoleId { get; private set; }
        //public string Notes { get; private set; }
        public RentalProperty RentalProperty { get; private set; }

        public OwnerAddress OwnerAddress { get; private set; }
    }
}
