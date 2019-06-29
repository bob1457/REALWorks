using REALWorks.MarketingCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.ValueObjects
{
    public class ListingContact : ValueObject
    {
        private ListingContact() { }

        public ListingContact(string contactName, string contactTel, 
            string contactEmail, string contactSMS, string contactOthers)
        {
            ContactName = contactName;
            ContactTel = contactTel;
            ContactEmail = contactEmail;
            ContactSMS = contactSMS;
            ContactOthers = contactOthers;
        }

        public string ContactName { get; private set; }
        public string ContactTel { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactSMS { get; private set; }
        public string ContactOthers { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
