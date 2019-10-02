using MediatR;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Commands
{
    public class CreateOpenHouseCommand : IRequest<OpenHouseViewModel>
    {
        public int RentalPropertyId { get; set; } // Command is readonly?
        public DateTime OpenhouseDate { get; set; }
        public bool IsActive { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Notes { get; set; }
    }
}
