using MediatR;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Queries
{
    public class GetBarChartDataQuery : IRequest<IQueryable<BarChartDataViewModel>>
    {
        public int Id { get; set; }
    }
}
