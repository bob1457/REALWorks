using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetData;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class GetBarChartDataQueryHandler : IRequestHandler<GetBarChartDataQuery, IQueryable<BarChartDataViewModel>>
    {
        private readonly AppDataBaseContext _context;

        public GetBarChartDataQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<BarChartDataViewModel>> Handle(GetBarChartDataQuery request, CancellationToken cancellationToken)
        {
            var query = (from p in _context.Property.Include(a => a.Address)
                         group p by p.Address.PropertyCity into s
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
