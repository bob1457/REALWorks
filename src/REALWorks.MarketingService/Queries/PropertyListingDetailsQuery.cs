using MediatR;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.Queries
{
    public class PropertyListingDetailsQuery: IRequest<PropertyListing>
    {
        public int Id { get; set; }
    }
}
