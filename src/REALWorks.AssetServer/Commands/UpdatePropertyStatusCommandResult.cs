using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.AssetCore.Entities.Property;

namespace REALWorks.AssetServer.Commands
{
    public class UpdatePropertyStatusCommandResult
    {
        public int Id { get; set; }
        public RentalStatus Status { get; set; }
        
        public string PropertyName { get; set; }
        public string PropertyLogoImgUrl { get; set; }
        public bool? IsActive { get; set; }
        public bool IsShared { get; set; }
        public bool IsBasementSuite { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string PropertyType1 { get; set; }

        public string PropertySuiteNumber { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyStateProvince { get; set; }
        public string PropertyCountry { get; set; }
        public string PropertyZipPostCode { get; set; }

        //public string Status { get; set; }
    }
}
