using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Events
{
    public class UpdateOwnerEvent : Event
    {
        public UpdateOwnerEvent(Guid messageId, int propertyOwnerId, string firstName, string lastName,
            string contactEmail, string contactTelephone1, string contactTelephone2,
            bool onlineAccessEnbaled, bool isActive, int roleId, string notes,
            string streetNumber, string city, string stateProv, string zipPostCode,
            string country) : base(messageId)
        {
            PropertyOwnerId = propertyOwnerId;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            OnlineAccessEnbaled = onlineAccessEnbaled;
            IsActive = isActive;
            RoleId = roleId;
            Notes = notes;
            StreetNumber = streetNumber;
            City = city;
            StateProv = stateProv;
            ZipPostCode = zipPostCode;
            Country = country;
        }

        public int PropertyOwnerId { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public bool OnlineAccessEnbaled { get; set; }
        //public string UserAvartaImgUrl { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public string Notes { get; set; }

        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string StateProv { get; set; }
        public string ZipPostCode { get; set; }
        public string Country { get; set; }
    }
}
