﻿using REALWorks.AssetCore.Base;
using REALWorks.AssetCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.Entities
{
    public class PropertyOwner: Entity, IAggeregateRoot
    {
        private PropertyOwner()
        {
            //OwnerProperty = new HashSet<OwnerProperty>();
        }

        public PropertyOwner(
            string userName,
            string firstName,
            string lastName,
            string contactEmail,
            string contactTelephone1,
            string contactTelephone2,
            bool onlineAccess,
            string userAvartaImgUrl,
            bool isActive,
            int roleId,
            string notes,
            //string streetNumber,
            //string city,
            //string stateProv,
            //string zipPostCode,
            //string country,
            OwnerAddress address,
            DateTime createdOn,
            DateTime updatedOn
            //ICollection<OwnerProperty> ownerProperty
            )
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = contactEmail;
            ContactTelephone1 = contactTelephone1;
            ContactTelephone2 = contactTelephone2;
            OnlineAccess = onlineAccess;
            UserAvartaImgUrl = userAvartaImgUrl;
            IsActive = isActive;
            RoleId = roleId;
            Notes = notes;
            
            Address = address;
            Created = createdOn;
            Modified = updatedOn;
            //OwnerProperty = ownerProperty;
        }

        //*********************************
        // Entity Properties
        //*********************************

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactTelephone1 { get; private set; }
        public string ContactTelephone2 { get; private set; }
        public bool OnlineAccess { get; private set; }
        public string UserAvartaImgUrl { get; private set; }
        public bool IsActive { get; private set; }
        public int RoleId { get; private set; }
        public string Notes { get; private set; }

        // Navigation properties

        public OwnerAddress Address { get; private set; }

        public List<OwnerProperty> OwnerProperty { get; private set; } = new List<OwnerProperty>();




        //*********************************
        // Entity Behavors
        //*********************************


        public void Update(/*PropertyOwner owner,*/ string firstName, string lastName, string email, 
            string telephone1, string telephone2, string avatarUrl, bool isActive, 
            string notes, OwnerAddress address)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = email;
            ContactTelephone1 = telephone1;
            ContactTelephone2 = telephone2;            
            UserAvartaImgUrl = avatarUrl;
            IsActive = isActive;
            Notes = notes;
            Address = address;
            Modified = DateTime.Now;

            //return owner;
        }

        public void Deactivate() // Deactivate/soft delete owner
        {
            // TO DO

        }

        public void ConfigOnlineAccess(bool status, string userName) // Enable/disable online owner access
        {
            // TO DO
            OnlineAccess = status;
            UserName = userName;
        }
    }
}
