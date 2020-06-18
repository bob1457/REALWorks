using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class ContractUpdateForProperty
    {
        public int Id  { get; set; }
        public string PropertyName { get; set; }

        public ContractUpdateFroPropertyAddress Address { get; set; }

        public IList<OwnerProperty> OwnerProperty { get; set; }
    }

    public class ContractUpdateFroPropertyAddress
    {
        public string PropertySuiteNUmber { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyStateProvince { get; set; }
        public string propertyZipPostCode { get; set; }
        public string propertyCountry { get; set; }
    }
}
