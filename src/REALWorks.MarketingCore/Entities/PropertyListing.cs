﻿using REALWorks.MarketingCore.Base;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class PropertyListing : Entity
    {
        private PropertyListing()
        {
        }

        public PropertyListing(string title, string listingDesc, 
            ListingContact contact, int rentalPropertyId, bool isActive,
            decimal rent, string notes,
            
            DateTime added, DateTime updated)
        {
            Title = title;            
            ListingDesc = listingDesc;
            Contact = contact;
            RentalPropertyId = rentalPropertyId;
            IsActive = isActive;
            MonthlyRent = rent;
            Note = notes;
            Created = added;
            Modified = updated;
        }

        public string Title { get; private set; }
        public int RentalPropertyId { get; private set; }
        public string ListingDesc { get; private set; }
        public decimal MonthlyRent { get; private set; }
        public bool IsActive { get; private set; }
        public string Note { get; private set; }

        public RentalProperty RentalProperty { get; private set; }
        public ListingContact Contact { get; private set; }


        public PropertyListing Update(
            PropertyListing listing,
            string title, 
            string listingDesc,
            ListingContact contact,
            decimal rent, 
            bool isActive, // add to update the publishing status -- may refactor in the future 
            string notes, 
            DateTime updated)
        {
            Title = title;
            ListingDesc = listingDesc;
            Contact = contact;
            MonthlyRent = rent;
            Note = notes;
            IsActive = isActive; // add to update the publishing status -- may refactor in the future 
            Modified = updated;

            return listing;
        }

        public PropertyListing StatusUpdate(PropertyListing listing, bool status)
        {
            listing.IsActive = status;
            listing.Modified = DateTime.Now;

            return this;
        }

        public void DeActivate(PropertyListing listing)
        {
            listing.IsActive = false;
            listing.Modified = DateTime.Now;
        }

        public void Publish(PropertyListing listing)
        {
            listing.IsActive = true;
            listing.Modified = DateTime.Now;
        }
    }
}
