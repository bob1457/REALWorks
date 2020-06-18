using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class UpdatedOwnerAddress
    {
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostCode { get; set; }
        public string Country { get; set; }
    }
}
