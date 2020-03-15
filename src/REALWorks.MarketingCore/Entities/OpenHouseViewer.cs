using REALWorks.MarketingCore.Base;
using REALWorks.MarketingCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class OpenHouseViewer : Entity
    {
        private OpenHouseViewer()
        {
        }

        public enum PreferredContact
        {
            NotSet,
            Email,
            SMS
        }

        public OpenHouseViewer(int openHouseId, string firstName, string lastName, 
            string contactTel, string contactEmail, int? numberOfPeople, PreferredContact contactType,
            DateTime created, DateTime updated)
        {
            OpenHouseId  = openHouseId;
            FirstName = firstName;
            LastName = lastName;
            ContactTel = contactTel;
            ContactEmail = contactEmail;
            NumberOfPeople = numberOfPeople;
            ContactType = contactType;
            Created = created;
            Modified = updated;
        }

                
        public int OpenHouseId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactTel { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactSms { get; private set; }
        public string ContactOthers { get; private set; }
        public int? NumberOfPeople { get; private set; }
        public PreferredContact ContactType { get; private set; } 

        public OpenHouse RentalProperty { get; private set; }


    }
}
