using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class PropertyDetailViewModel
    {
        /// <summary>
        /// Property Basic
        /// </summary>
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDesc { get; set; }        
        public string PropertyLogoImgUrl { get; set; }
        public string PropertyVideoUrl { get; set; }
        public int PropertyBuildYear { get; set; }
        public bool? IsActive { get; set; }
        public bool IsShared { get; set; }
        public bool IsBasementSuite { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string PropertyType1 { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string PropertySuiteNumber { get; set; }
        public string PropertyNumber { get; set; }
        public string PropertyStreet { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyStateProvince { get; set; }
        public string PropertyCountry { get; set; }
        public string PropertyZipPostCode { get; set; }
        public string GpslongitudeValue { get; set; }
        public string GpslatitudeValue { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public bool? OwnerIsActive { get; set; }        
        public DateTime OwnerCreationDate { get; set; }
        public DateTime OwnerpdateDate { get; set; }

        /// <summary>
        /// Owner
        /// </summary>
        public string ManagementContractTitile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PlacementFeeScale { get; set; }
        public string ManagementFeeScale { get; set; }
        public DateTime ContractSignDate { get; set; }
        
        /// <summary>
        /// Management Contract
        /// </summary>
        public string ManagementContractDocUrl { get; set; }
        public bool ContractIsActive { get; set; }
        public DateTime ContractCreationDate { get; set; }
        public DateTime ContractUpdateDate { get; set; }
    }
}
