using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingService.ViewModels;
using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Events
{
    public class RentalAppApprovedEvent: Event
    {
        /// <summary>
        /// Applicant
        /// </summary>
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string ContactEmail { get; }
        public string ContactTelephone1 { get; }
        public string ContactTelephone2 { get; }
        public string ContactOthers { get; }


        /// <summary>
        /// Rental Property
        /// </summary>
        public int PropertyId { get; }
        public int ListingId { get; }
        public string PropertyName { get; }
        public string PropertyManagerUserName { get; }
        public int PropertyBuildYear { get; }
        public string Type { get; }
        public bool IsBasementSuite;

        public string Notes { get; }

        public RentalAppApprovedEvent(Guid messageId, string userName, string firstName, string lastName, 
            string contactEmail, string contactTelephone1, string contactTelephone2, 
            string contactOthers, int propertyId, int listingId, string propertyName, 
            string propertyManagerUserName, int propertyBuildYear, string type, bool isBasementSuite, 
            bool isShared, int numberOfBedrooms, int numberOfBathrooms, int numberOfLayers, 
            int numberOfParking, int totalLivingArea, string streetNum, string city, 
            string stateProvince, string country, string zipPostCode, List<PropertyOwnerViewModel> propertyOwners
            /*string oStreetNum, string oCity, string oStateProvince, string oZipPostCode, string oCountry*/) : base(messageId)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            ContactOthers = contactOthers;
            PropertyId = propertyId; // originalId from Marketeing and Assets Manager
            ListingId = listingId;
            PropertyName = propertyName;
            PropertyManagerUserName = propertyManagerUserName;
            PropertyBuildYear = propertyBuildYear;
            Type = type;
            IsBasementSuite = isBasementSuite;
            IsShared = isShared;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfLayers = numberOfLayers;
            NumberOfParking = numberOfParking;
            TotalLivingArea = totalLivingArea;
            StreetNum = streetNum;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            ZipPostCode = zipPostCode;
            PropertyOwners = propertyOwners;
            //OwnerStreetNum = oStreetNum;
            //OwnerCity = oCity;
            //OwnerStateProvince = oStateProvince;
            //OwnerZipPostCode = oZipPostCode;
            //OwnerCountry = oCountry;
        }

        public bool IsShared { get; }
        public int NumberOfBedrooms { get; }
        public int NumberOfBathrooms { get; }
        public int NumberOfLayers { get; }
        public int NumberOfParking { get; }
        public int TotalLivingArea { get; }

        public string StreetNum { get; }
        public string City { get; }
        public string StateProvince { get; }
        public string Country { get; }
        public string ZipPostCode { get; }

        public IList<PropertyOwnerViewModel> PropertyOwners { get; }

        //public string OwnerStreetNum { get; set; }
        //public string OwnerCity { get; }
        //public string OwnerStateProvince { get; }
        //public string OwnerCountry { get; }
        //public string OwnerZipPostCode { get; }

    }
}
