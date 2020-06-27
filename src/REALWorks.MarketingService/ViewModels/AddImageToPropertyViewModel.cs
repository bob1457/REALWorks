using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.ViewModels
{
    public class AddImageToPropertyViewModel
    {
        public int Id { get; set; }
        public string PropertyImgTitle { get; set; }
        public string PropertyImgUrl { get; set; }
        public int RentalPropertyId { get; set; }
    }
}
