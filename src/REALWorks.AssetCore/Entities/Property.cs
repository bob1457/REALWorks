using REALWorks.AssetCore.Base;
using REALWorks.AssetCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class Property: Entity
    {
        public enum PropertyType
        {
           UnSet,
           SingleHouse,
           Apartment,
           TownHouse,          
           Others
        }

        public enum RentalStatus
        {
            UnSet,
            Rented,
            Vacant,
            Pending,
            BeingProcessing
        }

        private Property() {
            OwnerProperty = new HashSet<OwnerProperty>();
            PropertyImg = new HashSet<PropertyImg>();
        } // Required by EF Core

        /// <summary>
        /// All Domain Attributes(Domain Properties)
        /// </summary>
        //public int PropertyId { get; private set; }
        public string PropertyName { get; private set; }
        public string PropertyDesc { get; private set; }
        //public int PropertyTypeId { get; private set; } 
        public PropertyType Type { get; private set; }
        public int? StrataCouncilId { get; private set; }
        //public int PropertyAddressId { get; private set; }
        //public int PropertyFeatureId { get; private set; }
        //public int PropertyFacilityId { get; private set; }
        public int? PropertyManagerId { get; private set; }
        public string PropertyLogoImgUrl { get; private set; }
        public string PropertyVideoUrl { get; private set; }
        public int PropertyBuildYear { get; private set; }
        public bool? IsActive { get; private set; }
        public bool IsShared { get; private set; }
        //public int? FurnishingId { get; private set; }
        //public int RentalStatusId { get; private set; }
        public RentalStatus Status { get; private set; }
        public bool IsBasementSuite { get; private set; }
        //public DateTime CreatedDate { get; private set; }
        //public DateTime UpdateDate { get; private set; }

        /// <summary>
        /// Navigation
        /// </summary>
        public PropertyAddress Address { get; set; }
        public PropertyFacility Facility { get; set; }
        public PropertyFeature Feature { get; set; }
        //public PropertyType PropertyType { get; set; }
        //public RentalStatus RentalStatus { get; set; }

        
        public ICollection<OwnerProperty> OwnerProperty { get; set; }
        public ICollection<PropertyImg> PropertyImg { get; set; }


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
            PropertyFeature propertyFeature

            //int propertyTypeId, //PropertyType propertyType, 
            //int rentalStatusId
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


            Address = propertyAddress;
            Facility = propertyFacility;
            Feature = propertyFeature;

            //PropertyTypeId = propertyTypeId; //PropertyType = propertyType;
            //RentalStatusId = rentalStatusId;//RentalStatus = rentalStatus;
        }

    }
}
