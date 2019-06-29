using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.ValueObjects
{
    public class OwnerAddress : ValueObject
    {
        private OwnerAddress()
        {
        }

        public OwnerAddress(string streetNumber, string city, 
            string stateProvince, string country, string zipPostCode)
        {
            StreetNumber = streetNumber;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            ZipPostCode = zipPostCode;
        }

        /// <summary>
        /// All Domain Attributes(Domain Properties)
        /// </summary>
        public string StreetNumber { get; private set; }
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
