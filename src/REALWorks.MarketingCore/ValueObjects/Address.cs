using REALWorks.MarketingCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.ValueObjects
{
    public class Address : ValueObject
    {
        private Address()
        {
        }

        public Address(string streetNum, string city, string stateProvince, 
            string country, string zipPostCode)
        {
            StreetNum = streetNum;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            ZipPostCode = zipPostCode;
        }

        public string StreetNum { get; private set; }
        public string City { get; private set; }
        public string StateProvince { get; private set; }
        public string Country { get; private set; }
        public string ZipPostCode { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
