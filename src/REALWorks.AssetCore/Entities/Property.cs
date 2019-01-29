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

        private Property( ) {
            PropertyImg = new HashSet<PropertyImg>();
        }     

        /// <summary>
        /// All Domain Attributes(Domain Properties)
        /// </summary>
        public string PropertyName { get; private set; }
        public string PropertyDesc { get; private set; }
        public PropertyType Type { get; private set; }
        public int? StrataCouncilId { get; private set; }
        public string PropertyManagerUserName { get; private set; }
        public string PropertyLogoImgUrl { get; private set; }
        public string PropertyVideoUrl { get; private set; }
        public int PropertyBuildYear { get; private set; }
        public bool? IsActive { get; private set; }
        public bool IsShared { get; private set; }
        public RentalStatus Status { get; private set; }
        public bool IsBasementSuite { get; private set; }
        /// <summary>
        /// Navigation
        /// </summary>
        public PropertyAddress Address { get; private set; }
        public PropertyFacility Facility { get; private set; }
        public PropertyFeature Feature { get; private set; }

        public List<OwnerProperty> OwnerProperty { get; set; } = new List<OwnerProperty>();
        public ICollection<PropertyImg> PropertyImg { get; private set; }
        public ICollection<ManagementContract> ManagementContract { get; set; }



        /// <summary>
        /// Constructor - for creating new instance with all required parameters (enforced)
        /// </summary>
        ///
        public Property(
            string propertyName,
            string propertyDesc,
            PropertyType propertyType,
            int propertyBuildYear,
            bool isActive,
            bool isShared,
            RentalStatus rentalStatus,
            bool isBasementSuite,
            DateTime createdDate,
            DateTime updateDate,


            PropertyAddress propertyAddress,
            PropertyFacility propertyFacility,
            PropertyFeature propertyFeature

            )
        {
            PropertyName = propertyName;
            PropertyDesc = propertyDesc;
            Type = propertyType;
            PropertyBuildYear = propertyBuildYear;
            IsActive = isActive;
            IsShared = isShared;
            Status = rentalStatus;
            IsBasementSuite = isBasementSuite;
            Created = createdDate;
            Modified = updateDate;


            Address = propertyAddress;
            Facility = propertyFacility;
            Feature = propertyFeature;

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

            var ownerProperty = new OwnerProperty(this, owner);


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
            property.Modified = updateDate;
            property.Address = propertyAddress;
            property.Facility = propertyFacility;
            property.Feature = propertyFeature;
           
            return property;
            
        }

        public void Delete( Property property)   
        {
            property.IsActive = false;
            property.Modified = DateTime.Now;

        }


        public OwnerProperty AddExsitingOwner(PropertyOwner owner)
        {
            var op = new OwnerProperty(this, owner.Id);

            owner.OwnerProperty.Add(op);

            return op;  

        }

        public PropertyOwner AddNewOwnerToProperty(int propertyId, string userName, string firstName, 
            string lastName, string email, string telephone1, string telephone2, bool onlineAccess, 
            string avatarUrl, bool isActive, int roleId, string notes)
        {
            var owner = new PropertyOwner(userName, firstName, lastName, email, telephone1, 
                telephone2, onlineAccess, avatarUrl, isActive, roleId, notes, DateTime.Now, DateTime.Now);

            var ownerProperty = new OwnerProperty(propertyId, owner);

            owner.OwnerProperty.Add(ownerProperty);

            return owner;
        }

        public PropertyOwner UpdateOwner(PropertyOwner owner, string firstName, string lastName, string email,
            string telephone1, string telephone2, string avatarUrl, bool isActive,
            string notes)
        {
            owner.Update(firstName, lastName, email, telephone1, telephone2, avatarUrl, isActive, notes);

            return owner;

        }

        public OwnerProperty AddExistingOwnerToProperty(PropertyOwner owner, int propertyId)
        {
            var ownerProperty = new OwnerProperty(propertyId, owner.Id);

            owner.OwnerProperty.Add(ownerProperty);

            return ownerProperty;
        }

        public void RemoveOwnerFromProperty()
        {

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

        public Property AsssignPropertyManager(Property property, string pmUserName)
        {
            property.PropertyManagerUserName = pmUserName;

            return property;
        }


        public ManagementContract AddManabgementContract(int propertyId, string title, ContractType type,
            DateTime startDate, DateTime endDate, string placementFeeScale, string managementFeeScale, 
            DateTime signDate, bool isActive, string notes)
        {
            var contract = new ManagementContract(title, type, startDate, endDate, placementFeeScale, managementFeeScale, 
                signDate, propertyId, isActive, notes, DateTime.Now, DateTime.Now);

            return contract;
        }

        public ManagementContract UpdateContract(ManagementContract contract, string title, DateTime startDate, DateTime endDate,
            string placementFeeScale, string managementFeeScale, string notes)
        {
            contract.Update(title, startDate, endDate, placementFeeScale, managementFeeScale, notes);

            return contract;
        }

        public void UpdateManagementContractStatus(ManagementContract contract, bool status)
        {
            contract.SetStatus(status);
        }
    }
}
