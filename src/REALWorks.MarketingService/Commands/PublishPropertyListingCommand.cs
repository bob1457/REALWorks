using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Commands
{
    public class PublishPropertyListingCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
