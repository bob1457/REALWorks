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

            //var query = (from p in _context.RentalProperty.Include(a => a.Address)
            //                 .Where(s => s.Status == status) // Here ALL propeties will be displayed
            //                 //.SelectMany(g => g)
            //             group p by p.Address.City into s
            //             select new BarChartDataViewModel
            //             {
            //                 City = s.Key.ToString(),
            //                 Count = s.Count()
            //             }).AsQueryable();

            //var query = (from g in _context.GeoLocation
            //             join p in _context.RentalProperty on g.RentalPropertyId equals p.Id into pg
            //             //where (s.Status == status)
            //             from l in pg.DefaultIfEmpty()
            //             group l by g into grouped
            //             select new 
            //             {
            //                 Location = grouped.Key,
            //                 Count = grouped.Count(t => t.Id != null)
            //             });

            var query = from l in _context.GeoLocation
                        let pCount =
                        (
                            from p in _context.RentalProperty
                            where l.Id == p.GeoLocationId &&  p.Status == status
                            select p

                        ).Count()
                        select new BarChartDataViewModel
                        {
                            City = l.City.ToString(),
                            Count = pCount
                        };
            // Ref: https://hant-kb.kutu66.com/linq/post_186957

            //var query = (from g in _context.GeoLocation
            //             join p in _context.RentalProperty on g.Id equals p.GeoLocationId into pg
            //             //where (s.Status == status)
            //             from l in pg.DefaultIfEmpty()
            //             group l by g into grouped
            //             select new BarChartDataViewModel
            //             {
            //                 City = grouped.Key.ToString(),
            //                 Count = grouped.Count(t => t.Id != null)
            //             }).AsQueryable();


            return query;

            //throw new NotImplementedException();
        }
    }
}
