using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Queries;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class AllVendorsListQueryHandler : IRequestHandler<AllVendorsListQuery, IQueryable<Vendor>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AllVendorsListQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Vendor>> Handle(AllVendorsListQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            var vendors = _context.Vendor.ToList();

            return vendors.AsQueryable();
        }
    }
}
