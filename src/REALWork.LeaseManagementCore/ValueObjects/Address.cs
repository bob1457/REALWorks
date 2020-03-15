using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class Address : REALWorks.LeaseManagementCore.Base.ValueObject
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
        public int RentalPropertyId { get; private set; }

        public RentalProperty RentalProperty { get; private set; }


        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
