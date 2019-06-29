using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class NewTenant: Entity
    {
        private NewTenant()
        {
        }

        public NewTenant(string userName, string firstName, string lastName, 
            string contactEmail, string contactTelephone1, string contactTelephone2, string contactOthers, DateTime created, DateTime updated)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            ContactOthers = contactOthers;
            Created = created;
            Modified = updated;
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactTelephone1 { get; private set; }
        public string ContactTelephone2 { get; private set; }
        public string ContactOthers { get; private set; }
    }
}
