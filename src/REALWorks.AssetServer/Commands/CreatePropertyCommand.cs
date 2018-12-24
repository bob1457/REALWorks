using REALWorks.AssetServer.Common;
using REALWorks.AssetServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Commands
{
    public class CreatePropertyCommand: ICommand // input view model
    {
        /// <summary>
        /// Property Baisc
        /// </summary>
        /// 
        public int PropertyId { get; set; }
        [Required]
        public string PropertyName { get; set; }
        public string PropertyDesc { get; set; }
        public int PropertyTypeId { get; set; }
        public int PropertyManagerId { get; set; }
        public string PropertyLogoImgUrl { get; set; }
        public string PropertyVideoUrl { get; set; }
        public int PropertyBuildYear { get; set; }
        public bool IsActive { get; set; }
        public bool IsShared { get; set; }
        public int FurnishingId { get; set; }
        public int RentalStatusId { get; set; }
        public bool IsBasementSuite { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int PropertyAddressId { get; set; }
        public int PropertyFeatureId { get; set; }
        public int PropertyFacilityId { get; set; }
        public int PropertyOwnerId { get; set; }


        /// <summary>
        /// Property Address
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

        /// <summary>
        /// Property Facility
        /// </summary>
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

        /// <summary>
        /// Property Features
        /// </summary>
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfLayers { get; set; }
        public int NumberOfParking { get; set; }
        public bool BasementAvailable { get; set; }
        public int TotalLivingArea { get; set; }
        public string FeatureNotes { get; set; }

        /// <summary>
        /// Property Owner
        /// </summary>
        /// 
        //public int PropertyOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
        public int? RoleId { get; set; }

        public PropertyAddress PropertyAddress { get; set; }
        public PropertyFacility PropertyFacility { get; set; }
        public PropertyFeature PropertyFeature { get; set; }

        /// <summary>
        /// Constructor - for creating new instance with all required parameters (enforced)
        /// </summary>
        ///
        public CreatePropertyCommand(
            //int propertyId, 
            string propertyName,
            string propertyDesc,
            //int propertyTypeId, 
            //int? strataCouncilId, 
            //int propertyAddressId,
            //int propertyFeatureId,
            //int propertyFacilityId,
            //int? propertyOwnerId,
            //int? propertyManagerId,
            //string propertyLogoImgUrl, 
            //string propertyVideoUrl, 
            int propertyBuildYear,
            //int propertyMgmntlStatusId, 
            bool isActive,
            bool isShared,
            //int? furnishingId, 
            //int rentalStatusId, 
            bool isBasementSuite,
            //DateTime createdDate,
            //DateTime updateDate,
            PropertyAddress propertyAddress,
            PropertyFacility propertyFacility,
            PropertyFeature propertyFeature,

            int propertyTypeId, //PropertyType propertyType, 
            int rentalStatusId
            )
        {
            //PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyDesc = propertyDesc;
            //PropertyTypeId = propertyTypeId;
            //StrataCouncilId = strataCouncilId;
            //PropertyAddressId = propertyAddressId;
            //PropertyFeatureId = propertyFeatureId;
            //PropertyFacilityId = propertyFacilityId;
            //PropertyOwnerId = propertyOwnerId;
            //PropertyManagerId = propertyManagerId;
            //PropertyLogoImgUrl = propertyLogoImgUrl;
            //PropertyVideoUrl = propertyVideoUrl;
            PropertyBuildYear = propertyBuildYear;
            //PropertyMgmntlStatusId = propertyMgmntlStatusId;
            IsActive = isActive;
            IsShared = isShared;
            //FurnishingId = furnishingId;
            //RentalStatusId = rentalStatusId;
            IsBasementSuite = isBasementSuite;
            //CreatedDate = createdDate;
            //UpdateDate = updateDate;
            PropertyAddress = propertyAddress;
            PropertyFacility = propertyFacility;
            PropertyFeature = propertyFeature;

            PropertyTypeId = propertyTypeId; //PropertyType = propertyType;
            RentalStatusId = rentalStatusId;//RentalStatus = rentalStatus;
        }
    }
}
