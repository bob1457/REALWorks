using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class PropertyAddress
    {
        public PropertyAddress()
        {
            Community = new HashSet<Community>();
            Property = new HashSet<Property>();
        }

        public int PropertyAddressId { get; set; }
        public string PropertySuiteNumber { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyStateProvince { get; set; }
        public string PropertyCountry { get; set; }
        public string PropertyZipPostCode { get; set; }
        public string GpslongitudeValue { get; set; }
        public string GpslatitudeValue { get; set; }

        public ICollection<Community> Community { get; set; }
        public ICollection<Property> Property { get; set; }
    }
}
