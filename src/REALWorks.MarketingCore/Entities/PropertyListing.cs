using REALWorks.MarketingCore.Base;
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
            string notes, 
            DateTime updated)
        {
            Title = title;
            ListingDesc = listingDesc;
            Contact = contact;
            MonthlyRent = rent;
            Note = notes;
            Modified = updated;

            return listing;
        }

        public void StatusUpdate(PropertyListing listing, bool status)
        {
            listing.IsActive = status;
            listing.Modified = DateTime.Now;
        }
    }
}
