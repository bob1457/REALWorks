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

        public RentalPropertyOwner(int originalId, string firstName, string lastName, string contactEmail, 
            string contactTelephone, string contactOther, OwnerAddress ownerAddress, int rentalPropertyId, DateTime create, DateTime updated)
        {
            OriginalId = originalId;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone = contactTelephone;
            ContactOther = contactOther;
            OwnerAddress = ownerAddress;
            RentalPropertyId = rentalPropertyId;
            Created = create;
            Modified = updated;
        }

        public int OriginalId { get; private set; }
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


        public RentalPropertyOwner Update(RentalPropertyOwner owner, string firstName, string lastName, 
            string contactEmail, string contactTel, string contactOther, OwnerAddress address)
        {
            owner.FirstName = firstName;
            owner.LastName = lastName;
            owner.ContactEmail = ContactEmail;
            owner.ContactTelephone = ContactTelephone;
            owner.ContactOther = contactOther;
            owner.Modified = DateTime.Now;
            owner.OwnerAddress = address;

            return owner;

        }
    }
}
