using MediatR;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Commands
{
    public class UpdateOpenHouseCommand : IRequest<UpdateOpenHouseViewModel>
    {
        public int Id { get; set; } // Open house Id
        public int RentalPropertyId { get; set; } // Command is readonly?
        public DateTime OpenhouseDate { get; set; }
        public bool IsActive { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Notes { get; set; }
    }
}
