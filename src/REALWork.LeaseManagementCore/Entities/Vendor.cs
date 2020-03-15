using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class Vendor: Entity
    {
        private Vendor()
        {
        }

        public Vendor(/*int id, */string userName, string vendorBusinessName, string firstName, 
            string lastName, string vendorDesc, string vendorSpecialty, string vendorContactTelephone1, 
            string vendorContactOthers, string vendorContactEmail, bool isActive, int roleId, 
            bool onlineAccessEnbaled, string userAvartaImgUrl, DateTime creationDate, DateTime updateDate)
        {
            //Id = id;
            UserName = userName;
            VendorBusinessName = vendorBusinessName;
            FirstName = firstName;
            LastName = lastName;
            VendorDesc = vendorDesc;
            VendorSpecialty = vendorSpecialty;
            VendorContactTelephone1 = vendorContactTelephone1;
            VendorContactOthers = vendorContactOthers;
            VendorContactEmail = vendorContactEmail;
            IsActive = isActive;
            RoleId = roleId;
            OnlineAccessEnbaled = onlineAccessEnbaled;
            UserAvartaImgUrl = userAvartaImgUrl;
            Created = creationDate;
            Modified = updateDate;
        }

        //public int Id { get; private set; }
        public string UserName { get; private set; }
        public string VendorBusinessName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string VendorDesc { get; private set; }
        public string VendorSpecialty { get; private set; }
        public string VendorContactTelephone1 { get; private set; }
        public string VendorContactOthers { get; private set; }
        public string VendorContactEmail { get; private set; }
        public bool IsActive { get; private set; }
        public int RoleId { get; private set; }
        public bool OnlineAccessEnbaled { get; private set; }
        public string UserAvartaImgUrl { get; private set; }
        //public DateTime CreationDate { get; private set; }
        //public DateTime UpdateDate { get; private set; }

        public ICollection<WorkOrder> WorkOrder { get; private set; }


        public Vendor Update(string vendorBusinessName, string fristName, string lastName,
            string vendorSpecialty, string vendorContactTelephone1, string vendorContactOthers,
            string vendorContactEmail, bool isActive)
        {
            VendorBusinessName = vendorBusinessName;
            FirstName = fristName;
            LastName = lastName;
            VendorSpecialty = vendorSpecialty;
            VendorContactTelephone1 = vendorContactTelephone1;
            VendorContactOthers = vendorContactOthers;
            VendorContactEmail = vendorContactEmail;
            IsActive = isActive;

            return this;
        }

    }
}
