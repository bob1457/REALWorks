using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public class Address
    {
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string City { get; set; }
        public string ProvinceState { get; set; }
        public string PostZipCode { get; set; }
        public string Country { get; set; }
    }
}
