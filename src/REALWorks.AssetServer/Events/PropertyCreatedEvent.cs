using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Events
{
    public class PropertyCreatedEvent : Event
    {
        public readonly int PropertyId;
        public readonly string PropertyName;
        public readonly string PropertyManagerUserName;
        public readonly int PropertyBuildYear;
        public readonly string Type;
        public bool IsBasementSuite;

        public readonly bool IsShared;
        public readonly int NumberOfBedrooms;
        public readonly int NumberOfBathrooms;
        public readonly int NumberOfLayers;
        public readonly int NumberOfParking;
        public readonly int TotalLivingArea;

        public readonly string StreetNum;
        public readonly string City;
        public readonly string StateProvince;
        public readonly string Country;
        public readonly string ZipPostCode;

        public readonly string OwnerFirstName;
        public readonly string OwnerLastName;
        public readonly string OwnerContactEmail;
        public readonly string OwnerContactTel;
        public readonly string OwnerContactOther;

        public readonly string OwnerStreetNum;
        public readonly string OwnerCity;
        public readonly string OwnerStateProvince;
        public readonly string OwnerCountry;
        public readonly string OwnerZipPostCode;

        public PropertyCreatedEvent( 
            Guid messageId, 
            int propertyId, 
            string propertyName, 
            string pmUserName,
            int propertyBuildYear, 
            string type, 
            bool isBasementSuite,
            bool isShared,
            int numberOfBedrooms,
            int numberOfBathrooms,
            int numberOfLayers,
            int numberOfParking,
            int totalLivingArea,
            string streetNumber,
            string city,
            string stateProvince,
            string country,
            string zipPostCode,

            string ownerFirstName,
            string ownerLastName,
            string ownerContactEmail,
            string ownerConteactTel,
            string ownerContactOther,

            string ownerStreetNumber,
            string ownerCity,
            string ownerStateProv,
            string ownerZipPostCode,
            string ownerCountry
            ) : base(messageId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyManagerUserName = pmUserName;
            PropertyBuildYear = propertyBuildYear;
            Type = type;
            IsBasementSuite = isBasementSuite;
            IsShared = isShared;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfLayers = numberOfLayers;
            NumberOfParking = numberOfParking;
            TotalLivingArea = totalLivingArea;
            StreetNum = streetNumber;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            ZipPostCode = zipPostCode;

            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            OwnerContactEmail = ownerContactEmail;
            OwnerContactTel = ownerConteactTel;
            OwnerContactOther = ownerContactOther;

            OwnerStreetNum = ownerStreetNumber;
            OwnerCity = ownerCity;
            OwnerStateProvince = ownerStateProv;
            OwnerZipPostCode = ownerZipPostCode;
            OwnerCountry = ownerCountry;
        }

        //private PropertyCreatedEvent()
        //{
        //}
    }
}
