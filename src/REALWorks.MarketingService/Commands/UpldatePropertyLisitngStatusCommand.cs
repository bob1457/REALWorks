using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.Commands
{
    public class UpldatePropertyLisitngStatusCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public ListingStatus RentalPropertyStatus { get; set; }
    }
}
