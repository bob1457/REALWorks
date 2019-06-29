using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class Tenant: Entity
    {
        private Tenant()
        {
        }

        public Tenant(string userName, string firstName, string lastName, string contactEmail, 
            string contactTelephone1, string contactTelephone2, string contactOthers, 
            bool onlineAccessEnbaled, string userAvartaImgUrl, int roleId, bool isActive, 
            DateTime createDate, DateTime updateDate)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            ContactOthers = contactOthers;
            OnlineAccessEnbaled = onlineAccessEnbaled;
            UserAvartaImgUrl = userAvartaImgUrl;            
            RoleId = roleId;
            IsActive = isActive;
            Created = createDate;
            Modified = updateDate;
        }

        public Tenant(string userName, string firstName, string lastName, string contactEmail,
            string contactTelephone1, string contactTelephone2, string contactOthers,
            bool onlineAccessEnbaled, string userAvartaImgUrl, int roleId, bool isActive, int leaseId,
            DateTime createDate, DateTime updateDate)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            ContactOthers = contactOthers;
            OnlineAccessEnbaled = onlineAccessEnbaled;
            UserAvartaImgUrl = userAvartaImgUrl;
            RoleId = roleId;
            IsActive = isActive;
            LeaseId = leaseId;
            Created = createDate;
            Modified = updateDate;
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactTelephone1 { get; private set; }
        public string ContactTelephone2 { get; private set; }
        public string ContactOthers { get; private set; }
        public bool OnlineAccessEnbaled { get; private set; }
        public string UserAvartaImgUrl { get; private set; }
        public int LeaseId { get; private set; }
        public int RoleId { get; private set; }
        public bool IsActive { get; set; }
        

        public Lease Lease { get; private set; }



        public void Update(string firstName, string lastName, string contactEmail, string contactTel1,
            string contactTel2, string contactOthers)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTel1;
            ContactTelephone2 = contactTel2;
            ContactOthers = contactOthers;
            Modified = DateTime.Now;
        }
    }
}
