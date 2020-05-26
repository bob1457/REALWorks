using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace REALWorks.MarketingService.ViewModels
{
    public class PropertyListingListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }        //public int RentalPropertyId { get; set; }
        public string ListingDesc { get; set; }
        public decimal MonthlyRent { get; set; }
        public string ListingNote { get; set; }
        public bool IsActive { get; set; }

        public int RentalPropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public int PropertyBuildYear { get; set; }
        public bool IsShared { get; set; }
        //public ListingStatus Status { get; set; }
        public bool IsBasementSuite { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }


    }
}
