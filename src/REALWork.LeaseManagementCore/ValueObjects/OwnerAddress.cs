using System;
using System.Collections.Generic;
using System.Text;
using REALWorks.LeaseManagementCore.Base;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class OwnerAddress : ValueObject
    {
        private OwnerAddress()
        {
        }

        public OwnerAddress(string streetNumber, string city, string stateProvince,
            string country, string zipPostCode)
        {
            StreetNumber = streetNumber;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            ZipPostCode = zipPostCode;
        }

        public string StreetNumber { get; private set; }
        public string City { get; private set; }
        public string StateProvince { get; private set; }
        public string Country { get; private set; }
        public string ZipPostCode { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            //throw new NotImplementedException();

            yield return City;
        }
    }
}
