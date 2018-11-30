using System;
using System.Collections.Generic;
using System.Linq;

namespace REALWorks.AssetServer.Models
{
    public partial class Property
    {
        //public Property()
        //{
        //    OwnerProperty = new HashSet<OwnerProperty>();
        //    PropertyImg = new HashSet<PropertyImg>();
        //}

        private Property()
        {
            // Required by EF
        }

        /// <summary>
        /// Constructor
        /// </summary>

        public Property(
            //int propertyId, 
            string propertyName,
            string propertyDesc,
            //int propertyTypeId, 
            //int? strataCouncilId, 
            //int propertyAddressId, 
            //int propertyFeatureId, 
            //int propertyFacilityId, 
            //int propertyOwnerId, 
            int propertyManagerId,
            //string propertyLogoImgUrl, 
            //string propertyVideoUrl, 
            int propertyBuildYear,
            //int propertyMgmntlStatusId, 
            bool isActive,
            bool isShared,
            //int? furnishingId, 
            //int rentalStatusId, 
            bool isBasementSuite,
            DateTime createdDate,
            DateTime updateDate,
            //PropertyAddress propertyAddress, 
            //PropertyFacility propertyFacility, 
            //PropertyFeature propertyFeature, 
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
            PropertyManagerId = propertyManagerId;
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
            //PropertyAddress = propertyAddress;
            //PropertyFacility = propertyFacility;
            //PropertyFeature = propertyFeature;
            PropertyTypeId = propertyTypeId; //PropertyType = propertyType;
            RentalStatusId = rentalStatusId;//RentalStatus = rentalStatus;
        }

        /// <summary>
        /// The new code for complying with DDD principle
        /// </summary>
        private HashSet<PropertyImg> _propertyImgs;
        //private HashSet<OwnerProperty> _ownerProperty;
        private HashSet<PropertyOwner> _propertyOwner;

        public IEnumerable<PropertyImg> PropertyImgs => _propertyImgs?.ToList();
        //public IEnumerable<OwnerProperty> OwnerPropertyList => _ownerProperty?.ToList();
        public IEnumerable<PropertyOwner> PropertyOwner => _propertyOwner?.ToList();

        /// <summary>
        /// All Properties
        /// </summary>
        public int PropertyId { get; private set; }
        public string PropertyName { get; private set; }
        public string PropertyDesc { get; private set; }
        public int PropertyTypeId { get; private set; }
        public int? StrataCouncilId { get; private set; }
        public int PropertyAddressId { get; private set; }
        public int PropertyFeatureId { get; private set; }
        public int PropertyFacilityId { get; private set; }
        //public int PropertyOwnerId { get; set; }
        public int PropertyManagerId { get; private set; }
        public string PropertyLogoImgUrl { get; private set; }
        public string PropertyVideoUrl { get; private set; }
        public int PropertyBuildYear { get; private set; }
        //public int PropertyMgmntlStatusId { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsShared { get; private set; }
        public int FurnishingId { get; private set; }
        public int RentalStatusId { get; set; }
        public bool IsBasementSuite { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdateDate { get; private set; }

        public PropertyAddress PropertyAddress { get; private set; }
        public PropertyFacility PropertyFacility { get; private set; }
        public PropertyFeature PropertyFeature { get; private set; }
        public PropertyType PropertyType { get; private set; }
        public RentalStatus RentalStatus { get; private set; }


        public ICollection<OwnerProperty> OwnerProperty { get; private set; }
        public ICollection<PropertyImg> PropertyImg { get; private set; }

        public static Property CreateProperty(
            string Name, 
            string Desc,
            int ManerId,
            int Year, 
            bool Active, 
            bool Shared, 
            bool Basement, 
            //PropertyType Type, 
            //RentalStatus Status//,
            int TypeId,
            int StatusId
            //DateTime Created,
            //DateTime Updated
            )
        {
            Property property = new Property()
            {
                PropertyName = Name,
                PropertyDesc = Desc,
                PropertyManagerId = ManerId,                
                PropertyBuildYear = Year,
                IsActive = Active,
                IsShared = Shared,
                IsBasementSuite = Basement,
                PropertyTypeId = TypeId,
                RentalStatusId = StatusId//,
                //CreatedDate = Created,
                //UpdateDate = Updated
            };

            return property;
        }
    }
}
