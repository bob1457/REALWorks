using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.ViewModels
{
    public class PropertyListingDetailsViewModel
    {
        public string Title { get; set; }       
        public string ListingDesc { get; set; }
        public decimal MonthlyRent { get; set; }
        public string ListingNote { get; set; }
        public bool IsActive { get; set; }


        public int RentalPropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public int PropertyBuildYear { get; set; }
        public bool IsShared { get; set; }
        public ListingStatus Status { get; set; }
        public bool IsBasementSuite { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfLayers { get; set; }
        public int NumberOfParking { get; set; }
        public int TotalLivingArea { get; set; }
        public string Notes { get; set; }

        public string StreetNum { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string ZipPostCode { get; set; }
    }
}
