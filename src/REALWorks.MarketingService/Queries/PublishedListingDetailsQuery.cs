using MediatR;
using REALWorks.MarketingCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Queries
{
    public class PublishedListingDetailsQuery : IRequest<PropertyListing>
    {
        public int Id { get; set; }
    }
}
