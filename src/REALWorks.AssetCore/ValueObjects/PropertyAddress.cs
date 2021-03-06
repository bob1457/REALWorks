﻿using REALWorks.AssetCore.Base;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.ValueObjects
{
    public class PropertyAddress: ValueObject
    {
        private PropertyAddress() { }     

        public PropertyAddress(string propertySuiteNumber, 
            string propertyNumber, 
            string propertyStreet, 
            string propertyCity, 
            string propertyStateProvince, 
            string propertyZipPostCode, 
            string propertyCountry
            )
        {
            PropertySuiteNumber = propertySuiteNumber;
            PropertyNumber = propertyNumber;
            PropertyStreet = propertyStreet;
            PropertyCity = propertyCity;
            PropertyStateProvince = propertyStateProvince;
            PropertyCountry = propertyCountry;
            PropertyZipPostCode = propertyZipPostCode;
        }




        /// <summary>
        /// All Domain Attributes(Domain Properties)
        /// </summary>       
        public string PropertySuiteNumber { get; private set; }
        public string PropertyNumber { get; private set; }
        public string PropertyStreet { get; private set; }
        public string PropertyCity { get; private set; }
        public string PropertyStateProvince { get; private set; }
        public string PropertyCountry { get; private set; }
        public string PropertyZipPostCode { get; private set; }
        public string GpslongitudeValue { get; private set; }
        public string GpslatitudeValue { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Relations - Navigation
        /// </summary>
    }
}
