using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class AllRentPaymentHistoryQueryHandler : IRequestHandler<AllRentPaymentHistoryQuery, IQueryable<RentPayment>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AllRentPaymentHistoryQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<RentPayment>> Handle(AllRentPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            return _context.RentPayment
                .Include(p => p.Lease)
                .ThenInclude(l => l.RentalProperty)
                .AsQueryable();
        }
    }
}
