using MediatR;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Queries
{
    public class PublishedListingDetailsQuery : IRequest<PublishedListingListViewModel>
    {
        public int Id { get; set; }
    }
}
