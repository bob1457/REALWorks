﻿using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Events
{
    public class AddOwnerEvent : Event
    {
        public AddOwnerEvent(Guid messageId, int propertyId, string userName, string firstName,
            string lastName, string contactEmail, string contactTelephone1,
            string contactTelephone2, bool onlineAccessEnbaled, string userAvartaImgUrl,
            bool isActive, int roleId, string notes, string streetNumber, string city,
            string stateProv, string zipPostCode, string country) : base(messageId)
        {
            PropertyId = propertyId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            OnlineAccessEnbaled = onlineAccessEnbaled;
            UserAvartaImgUrl = userAvartaImgUrl;
            IsActive = isActive;
            RoleId = roleId;
            Notes = notes;
            StreetNumber = streetNumber;
            City = city;
            StateProv = stateProv;
            ZipPostCode = zipPostCode;
            Country = country;
        }

        public int PropertyId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public bool OnlineAccessEnbaled { get; set; }
        public string UserAvartaImgUrl { get; set; }
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
