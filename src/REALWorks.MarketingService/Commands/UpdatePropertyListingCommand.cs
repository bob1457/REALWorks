using MediatR;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Commands
{
    public class UpdatePropertyListingCommand: IRequest<PropertyListingUpdateViewModel>
    {
        public int Id { get; set; }
        public string Title { get; set; }        
        public string ListingDesc { get; set; }
        //public ListingStatus Status { get; set; }
        public decimal MonthlyRent { get; set; }
        public string Notes { get; set; }

        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSMS { get; set; }
        public string ContactOthers { get; set; }


    }
}
