using MediatR;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class GetPieChartDataQueryHandler : IRequestHandler<GetPieChartDataQuery, IQueryable<ChartDataViewModel>>
    {
        private readonly AppDataBaseContext _context;

        public GetPieChartDataQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<ChartDataViewModel>> Handle(GetPieChartDataQuery request, CancellationToken cancellationToken)
        {
            var query = (from p in _context.Property
                        group p by p.Status into s
                        select new ChartDataViewModel
                        {
                            Status = s.Key.ToString(),
                            Count = s.Count()
                        }).AsQueryable();

            return query;

            //throw new NotImplementedException();
        }

    }
}
