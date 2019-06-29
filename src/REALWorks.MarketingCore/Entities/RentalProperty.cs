using REALWorks.MarketingCore.Base;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class RentalProperty: Entity
    {
        private RentalProperty()
        {

        }

        //private RentalProperty(int propertyId, string propertyName)
        //{
        //    OpenHouse = new HashSet<OpenHouse>();
        //    PropertyImg = new HashSet<PropertyImg>();
        //    PropertyListing = new HashSet<PropertyListing>();
        //    RentalApplication = new HashSet<RentalApplication>();
        //}

        public enum ListingStatus
        {
            NotSet,
            Listed,
            Pending, // Pending applications that are in the process of screening
            Rented,
            Other
        }

        public RentalProperty(int originalId, string propertyName, string propertyType, string pmUserName,
            int propertyBuildYear, bool isShared, /*ListingStatus listingStatus,*/ bool isBasementSuite, 
            int numberOfBedrooms, int numberOfBathrooms, int numberOfLayers, int numberOfParking, 
            int totalLivingArea, string notes, DateTime createdOn, DateTime updatedOn, Address address, ICollection<RentalPropertyOwner> owner)
        {
            OriginalId = originalId;
            PropertyName = propertyName;
            PropertyType = propertyType;

            PmUserName = pmUserName;

            PropertyBuildYear = propertyBuildYear;
            IsShared = isShared;
            //Status = listingStatus;
            IsBasementSuite = isBasementSuite;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfLayers = numberOfLayers;
            NumberOfParking = numberOfParking;
            TotalLivingArea = totalLivingArea;
            Notes = notes;
            Created = createdOn;
            Modified = updatedOn;
            Address = address;
            RentalPropertyOwner = owner;
        }

        
        public int OriginalId { get; private set; }
        public string PropertyName { get; private set; }
        public string PropertyType { get; private set; }
        public int PropertyBuildYear { get; private set; }
        public bool IsShared { get; private set; }
        public ListingStatus Status { get; private set; }
        public bool IsBasementSuite { get; private set; }
        public int NumberOfBedrooms { get; private set; }
        public int NumberOfBathrooms { get; private set; }
        public int NumberOfLayers { get; private set; }
        public int NumberOfParking { get; private set; }
        public int TotalLivingArea { get; private set; }

        //public int RenatalPropertyId { get; private set; }

        public string PmUserName { get; private set; } // newly added

        public string Notes { get; private set; }


        public Address Address { get; private set; }
        //public RentalPropertyOwner Owner { get; private set; }
        public ICollection<RentalPropertyOwner> RentalPropertyOwner { get; private set; }
        public ICollection<OpenHouse> OpenHouse { get; private set; }
        public ICollection<PropertyImg> PropertyImg { get; private set; }
        public ICollection<PropertyListing> PropertyListing { get; private set; }
        public ICollection<RentalApplication> RentalApplication { get; private set; }


        public void ListingStatusUpdate(RentalProperty property, ListingStatus status)
        {
            property.Status = status;
            property.Modified = DateTime.Now;
        }

        public PropertyImg AddImages(string propertyImgTitle, string propertyImgUrl,
            int rentalPropertyId)
        {
            var img = new PropertyImg(propertyImgTitle, propertyImgUrl, rentalPropertyId);

            img.Created = DateTime.Now;
            img.Modified = DateTime.Now;

            //PropertyImg.Add(img);

            return img;
        }

        public RentalProperty StatusUpdate(ListingStatus status)
        {
            Status = status;
            Modified = DateTime.Now;

            return this;
        }

    }
}
