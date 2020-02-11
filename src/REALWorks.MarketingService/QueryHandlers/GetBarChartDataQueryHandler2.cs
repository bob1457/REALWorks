using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Queries;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.QueryHandlers
{
    public class GetBarChartDataQueryHandler2 : IRequestHandler<GetBarChartDataQuery2, IQueryable<BarChartDataViewModel>>
    {
        private readonly AppMarketingDbDataContext _context;

        public GetBarChartDataQueryHandler2(AppMarketingDbDataContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<BarChartDataViewModel>> Handle(GetBarChartDataQuery2 request, CancellationToken cancellationToken)
        {
            //string status = Enum.GetName(typeof(ListingStatus), ListingStatus.Rented);

            ListingStatus status = (ListingStatus)Enum.Parse(typeof(ListingStatus), "Listed");

            var query = (from p in _context.RentalProperty.Include(a => a.Address)                         
                         //.Where(s => s.Status == status) // Here ALL propeties will be displayed
                         //.SelectMany(g => g)
                         group p by p.Address.City into s
                         select new BarChartDataViewModel
                         {
                             City = s.Key.ToString(),
                             Count = s.Count()
                         }).AsQueryable();

            return query;

            //throw new NotImplementedException();
        }
    }
}
