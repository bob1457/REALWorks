using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Services.ViewModels
{
    public class PropertyListViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }        
        public string PropertyLogoImgUrl { get; set; }
        //public string PropertyVideoUrl { get; set; }
        //public int PropertyId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsShared { get; set; }
        //public int? FurnishingId { get; set; }
        //public int RentalStatusId { get; set; }
        public bool IsBasementSuite { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string PropertyType1 { get; set; }        

        public string Status { get; set; }
        
    }
}
