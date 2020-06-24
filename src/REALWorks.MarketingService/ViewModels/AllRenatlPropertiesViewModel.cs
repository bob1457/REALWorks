using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.ViewModels
{
    public class AllRenatlPropertiesViewModel
    {
        public int Id { get; set; }
        
        public string PropertyName { get;  set; }
        public ListingStatus Status { get;  set; }
        /**
         *  The following attributes may need in the future


        /*
        public int OriginalId { get;  set; }
        public string PropertyType { get;  set; }
        public int PropertyBuildYear { get;  set; }
        public bool IsShared { get;  set; }
        
        public bool IsBasementSuite { get;  set; }
        public int NumberOfBedrooms { get;  set; }
        public int NumberOfBathrooms { get;  set; }
        public int NumberOfLayers { get;  set; }
        public int NumberOfParking { get;  set; }
        public int TotalLivingArea { get;  set; }

        //public int RenatalPropertyId { get;  set; }

        public string PmUserName { get;  set; } // newly added

        public string Notes { get;  set; }


        public Address Address { get;  set; }
        //public RentalPropertyOwner Owner { get;  set; }
        public ICollection<RentalPropertyOwner> RentalPropertyOwner { get;  set; }
        public ICollection<OpenHouse> OpenHouse { get;  set; }
        public ICollection<PropertyImg> PropertyImg { get;  set; }
        public ICollection<PropertyListing> PropertyListing { get;  set; }
        public ICollection<RentalApplication> RentalApplication { get;  set; }
      */
    }
}
