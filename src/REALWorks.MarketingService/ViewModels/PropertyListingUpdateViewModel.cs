using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.ViewModels
{
    public class PropertyListingUpdateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }        //public int RentalPropertyId { get; set; }
        public string ListingDesc { get; set; }
        public decimal MonthlyRent { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        // Listing contact
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSMS { get; set; }
        public string ContactOthers { get; set; }

        public RentalProperty RentalProperty { get; set; }

        public ListingContact Contact { get; set; }
    }
}
