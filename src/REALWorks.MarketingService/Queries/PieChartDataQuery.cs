using MediatR;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Queries
{
    public class PieChartDataQuery: IRequest<IQueryable<PieChartDataViewModel>>
    {
        public int Id { get; set; }
    }
}
