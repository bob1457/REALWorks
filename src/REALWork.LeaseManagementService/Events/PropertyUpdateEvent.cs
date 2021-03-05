using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Events
{
    public class PropertyUpdateEvent : Event
    {
        public readonly int PropertyId;
        public readonly string PropertyName;
        //public readonly string PropertyManagerUserName;
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

        public PropertyUpdateEvent(Guid messageId, int propertyId, string propertyName,
            int propertyBuildYear, string type, bool isBasementSuite, bool isShared, int numberOfBedrooms,
            int numberOfBathrooms, int numberOfLayers, int numberOfParking, int totalLivingArea, string streetNum,
            string city, string stateProvince, string country, string zipPostCode) : base(messageId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            //PropertyManagerUserName = propertyManagerUserName;
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
        }
    }
}
