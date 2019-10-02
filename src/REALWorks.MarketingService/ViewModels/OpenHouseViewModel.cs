using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.ViewModels
{
    public class OpenHouseViewModel
    {
        public int Id { get; set; }
        public int RentalPropertyId { get;  set; }
        public DateTime OpenhouseDate { get;  set; }
        public bool IsActive { get;  set; }
        public string StartTime { get;  set; }
        public string EndTime { get;  set; }
        public string Notes { get;  set; }

        public string PropertyName { get;  set; }
        public string PropertyType { get;  set; }
        public int PropertyBuildYear { get;  set; }
        public bool IsShared { get;  set; }
        public ListingStatus Status { get;  set; }
        public bool IsBasementSuite { get;  set; }
        public int NumberOfBedrooms { get;  set; }
        public int NumberOfBathrooms { get;  set; }
        public int NumberOfLayers { get;  set; }
        public int NumberOfParking { get;  set; }
        public int TotalLivingArea { get;  set; } 
        public string PropertyNotes { get;  set; }

        public string contactName { get; set; }
        public string contactTel { get; set; }
        public string contacEmail { get; set; }

        public string streetNumber { get;  set; }
        public string streetCity { get; set; }
        public string streetProvState { get; set; }
        public string streetPostZipCode { get; set; }
        
        

    }
}
