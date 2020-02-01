using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Queries;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.QueryHandlers
{
    public class PieChartDataQueryHandler : IRequestHandler<PieChartDataQuery, IQueryable<PieChartDataViewModel>>
    {
        private readonly AppMarketingDbDataContext _context;

        public PieChartDataQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<PieChartDataViewModel>> Handle(PieChartDataQuery request, CancellationToken cancellationToken)
        {
            var query = (from p in _context.RentalProperty
                         group p by p.Status into g
                         select new PieChartDataViewModel
                         {
                             Status = g.Key.ToString(),
                             Count = g.Count()
                             //status = g.Key.ToString(),
                             //count = g.Count()
                         }).AsQueryable();

            return query;

            //throw new NotImplementedException();
        }
    }
}
