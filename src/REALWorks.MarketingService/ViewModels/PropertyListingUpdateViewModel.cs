using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.ViewModels
{
    public class PropertyListingUpdateViewModel
    {
        public string Title { get; set; }        //public int RentalPropertyId { get; set; }
        public string ListingDesc { get; set; }
        public decimal MonthlyRent { get; set; }
        public string ListingNote { get; set; }
        public bool IsActive { get; set; }

        // Listing contact
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSMS { get; set; }
        public string ContactOthers { get; set; }
    }
}
