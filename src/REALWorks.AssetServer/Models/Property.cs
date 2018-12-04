using REALWorks.AssetServer.Data;
using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class Property
    {
        public Property()
        {
            OwnerProperty = new HashSet<OwnerProperty>();
            PropertyImg = new HashSet<PropertyImg>();
        }

        /// <summary>
        /// Inject database context if full ddd pattern is used
        /// </summary>
        private readonly REALAssetContext _context;

        public Property(REALAssetContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Constructor - for creating new instance with all required parameters (enforced)
        /// </summary>
        ///
        public Property(
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

        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDesc { get; set; }
        public int PropertyTypeId { get; set; }
        public int? StrataCouncilId { get; set; }
        public int PropertyAddressId { get; set; }
        public int PropertyFeatureId { get; set; }
        public int PropertyFacilityId { get; set; }
        public int? PropertyManagerId { get; set; }
        public string PropertyLogoImgUrl { get; set; }
        public string PropertyVideoUrl { get; set; }
        public int PropertyBuildYear { get; set; }
        public bool? IsActive { get; set; }
        public bool IsShared { get; set; }
        public int? FurnishingId { get; set; }
        public int RentalStatusId { get; set; }
        public bool IsBasementSuite { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public PropertyAddress PropertyAddress { get; set; }
        public PropertyFacility PropertyFacility { get; set; }
        public PropertyFeature PropertyFeature { get; set; }
        public PropertyType PropertyType { get; set; }
        public RentalStatus RentalStatus { get; set; }
        public ICollection<OwnerProperty> OwnerProperty { get; set; }
        public ICollection<PropertyImg> PropertyImg { get; set; }
    }
}
