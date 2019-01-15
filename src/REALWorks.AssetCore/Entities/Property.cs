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

        private Property(/*string propertyName*/) {
            //OwnerProperty = new HashSet<OwnerProperty>();
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
        //public int? PropertyManagerId { get; private set; }
        public string PropertyManagerUserName { get; private set; }
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
        public PropertyAddress Address { get; private set; }
        public PropertyFacility Facility { get; private set; }
        public PropertyFeature Feature { get; private set; }
        //public PropertyType PropertyType { get; set; }
        //public RentalStatus RentalStatus { get; set; }


        //public ICollection<OwnerProperty> OwnerProperty { get; set; }
        public List<OwnerProperty> OwnerProperty { get; set; } = new List<OwnerProperty>();
        public ICollection<PropertyImg> PropertyImg { get; private set; }



        /// <summary>
        /// Constructor - for creating new instance with all required parameters (enforced)
        /// </summary>
        ///
        public Property(
            //int propertyId, 
            string propertyName,
            string propertyDesc,
            PropertyType propertyType,
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
            RentalStatus rentalStatus,
            bool isBasementSuite,
            DateTime createdDate,
            DateTime updateDate,


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
            Type = propertyType;
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
            Status = rentalStatus;
            IsBasementSuite = isBasementSuite;
            Created = createdDate;
            Modified = updateDate;


            Address = propertyAddress;
            Facility = propertyFacility;
            Feature = propertyFeature;

            //PropertyTypeId = propertyTypeId; //PropertyType = propertyType;
            //RentalStatusId = rentalStatusId;//RentalStatus = rentalStatus;
        }

        public PropertyOwner AddOwner(
            string userName, 
            string firstName,
            string lastName,
            string contactEmail,
            string contactTelephone1,
            string contactTelephone2,
            bool onlineAccess,
            string userAvartaImgUrl,
            bool? isActive,
            int? roleId,
            string notes)
        {
            var owner = new PropertyOwner(userName, firstName, lastName, contactEmail, 
                contactTelephone1, contactTelephone2, false, userAvartaImgUrl, true, 2, "", 
                DateTime.Now, DateTime.Now);

            var ownerProperty = new OwnerProperty();


            ownerProperty.Property = this;
            ownerProperty.PropertyOwner = owner;

            owner.OwnerProperty.Add(ownerProperty);

            return owner;

        }


        public Property Update(
            Property property,
            string propertyName,
            string propertyDesc,
            PropertyType propertyType,
            int propertyBuildYear,
            bool isActive,
            bool isShared,
            RentalStatus rentalStatus,
            bool isBasementSuite,
            //DateTime createDate,
            DateTime updateDate,
            PropertyAddress propertyAddress,
            PropertyFacility propertyFacility,
            PropertyFeature propertyFeature
            )
        {
            property.PropertyName = propertyName;
            property.PropertyDesc = propertyDesc;
            property.Type = propertyType;
            property.PropertyBuildYear = propertyBuildYear;
            property.IsActive = isActive;
            property.IsShared = isShared;
            property.IsBasementSuite = isBasementSuite;
            //property.Created = createDate;
            property.Modified = updateDate;
            property.Address = propertyAddress;
            property.Facility = propertyFacility;
            property.Feature = propertyFeature;

            //property = new Property(

            //propertyName,
            //    ,
            //    propertyType,
            //    propertyBuildYear,
            //    isActive,
            //    isShared,
            //    rentalStatus,
            //    isBasementSuite,
            //    createDate,
            //    updateDate,
            //    propertyAddress,
            //    propertyFacility,
            //    propertyFeature
                //);


            return property;
            
        }



        public OwnerProperty AddExsitingOwner(PropertyOwner owner)
        {
            var ownerProperty = new OwnerProperty();

            ownerProperty.Property =this;
            ownerProperty.PropertyOwnerId = owner.Id;

            owner.OwnerProperty.Add(ownerProperty);

            return ownerProperty;

        }

        public void AddImages(string propertyImgTitle, 
            string propertyImgCaption, int propertyId)
        {
            var img = new PropertyImg(propertyImgTitle, propertyImgCaption, propertyId);

            PropertyImg.Add(img);
        }
    }
}
