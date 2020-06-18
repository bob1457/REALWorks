using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.AssetCore.Entities.Property;

namespace REALWorks.AssetServer.Commands
{
    public class UpdatePropertyCommandResult
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDesc { get; set; }
        public string PropertyType1 { get; set; }
        //public int PropertyManagerId { get; set; }
        public string PropertyLogoImgUrl { get; set; }
        //public string PropertyVideoUrl { get; set; }
        public int PropertyBuildYear { get; set; }
        public bool IsActive { get; set; }
        public bool IsShared { get; set; }
        //public int FurnishingId { get; set; }
        public string Status { get; set; }
        //public bool IsBasementSuite { get; set; }       
        public string PropertySuiteNumber { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyStateProvince { get; set; }
        public string PropertyCountry { get; set; }
        public string PropertyZipPostCode { get; set; }         
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }



        public bool Stove { get; set; }
        public bool Refrigerator { get; set; }
        public bool Dishwasher { get; set; }
        public bool AirConditioner { get; set; }
        public bool Laundry { get; set; }
        public bool BlindsCurtain { get; set; }
        public bool Furniture { get; set; }
        public bool Tvinternet { get; set; }
        public bool CommonFacility { get; set; }
        public bool SecuritySystem { get; set; }
        public bool UtilityIncluded { get; set; }
        public bool FireAlarmSystem { get; set; }
        public string Others { get; set; }
        public string FacilityNotes { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfLayers { get; set; }
        public int NumberOfParking { get; set; }
        public bool BasementAvailable { get; set; }
        public int TotalLivingArea { get; set; }
        public string FeatureNotes { get; set; }

        public IList<PropertyOwner> OwnerList  { get; set; }

        public IList<ManagementContract> ContractList { get; set; }
    }
}
