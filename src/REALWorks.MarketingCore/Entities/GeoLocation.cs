using REALWorks.MarketingCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class GeoLocation : Entity
    {
        private GeoLocation()
        {
        }

        public GeoLocation(string city, string stateProv, string region, string country)
        {
            City = city;
            StateProv = stateProv;
            Region = region;
            Country = country;
        }

        public string City { get; private set; }
        public string StateProv { get; private set; }
        public string Region { get; private set; }
        public string Country { get; private set; }
    }
}
