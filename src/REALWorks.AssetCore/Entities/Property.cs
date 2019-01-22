using REALWorks.AssetCore.Base;
using REALWorks.AssetCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static REALWorks.AssetCore.Entities.ManagementContract;

namespace REALWorks.AssetCore.Entities
{
    public class Property: Entity, IAggeregate
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
        public ICollection<ManagementContract> ManagementContract { get; set; }



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

/// <summary>
/// Domain behaviours - methods/operations
/// </summary>

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
           
            return property;
            
        }

        public void Delete( Property property) // Soft delete/de-active
        {
            // TO DO
            property.IsActive = false;
            property.Modified = DateTime.Now;

        }


        public OwnerProperty AddExsitingOwner(PropertyOwner owner)
        {
            var ownerProperty = new OwnerProperty();

            ownerProperty.Property = this;
            ownerProperty.PropertyOwnerId = owner.Id;

            owner.OwnerProperty.Add(ownerProperty);

            return ownerProperty;

        }

        public PropertyOwner AddNewOwnerToProperty(int propertyId, string userName, string firstName, 
            string lastName, string email, string telephone1, string telephone2, bool onlineAccess, 
            string avatarUrl, bool isActive, int roleId, string notes)
        {
            var owner = new PropertyOwner(userName, firstName, lastName, email, telephone1, 
                telephone2, onlineAccess, avatarUrl, isActive, roleId, notes, DateTime.Now, DateTime.Now);

            var ownerProperty = new OwnerProperty(propertyId, owner);

            //ownerProperty.PropertyId = propertyId;
            //ownerProperty.PropertyOwner = owner;

            owner.OwnerProperty.Add(ownerProperty);

            return owner;
        }

        public PropertyOwner UpdateOwner(PropertyOwner owner, string firstName, string lastName, string email,
            string telephone1, string telephone2, string avatarUrl, bool isActive,
            string notes)
        {
            owner.Update(firstName, lastName, email, telephone1, telephone2, avatarUrl, isActive, notes);

            return owner;

            //throw new NotImplementedException();
        }

        public OwnerProperty AddExistingOwnerToProperty(PropertyOwner owner, int propertyId)
        {
            var ownerProperty = new OwnerProperty(propertyId, owner.Id);

            //ownerProperty.PropertyId = propertyId;
            //ownerProperty.PropertyOwnerId = propertyOwnerId;

            owner.OwnerProperty.Add(ownerProperty);

            return ownerProperty;
        }

        public PropertyImg AddImages(string propertyImgTitle, string propertyImgUrl, int propertyId)
        {
            var img = new PropertyImg(propertyImgTitle, propertyImgUrl, propertyId);

            img.Created = DateTime.Now;
            img.Modified = DateTime.Now;

            PropertyImg.Add(img);

            return img;
        }

        
        public Property StatusUpdate(Property property, RentalStatus status)
        {
            property.Status = status;
            property.Modified = DateTime.Now;

            return property;
        }


        public ManagementContract AddManabgementContract(int propertyId, string title, ContractType type,
            DateTime startDate, DateTime endDate, string placementFeeScale, string managementFeeScale, 
            DateTime signDate, bool isActive, string notes)
        {
            var contract = new ManagementContract(title, type, startDate, endDate, placementFeeScale, managementFeeScale, 
                signDate, propertyId, isActive, notes, DateTime.Now, DateTime.Now);

            //contract.Created = DateTime.Now;
            //contract.Modified = DateTime.Now;

            return contract;
        }

        public ManagementContract UpdateContract(ManagementContract contract, string title, DateTime startDate, DateTime endDate,
            string placementFeeScale, string managementFeeScale, string notes)
        {
            contract.Update(title, startDate, endDate, placementFeeScale, managementFeeScale, notes);

            return contract;
        }
    }
}
