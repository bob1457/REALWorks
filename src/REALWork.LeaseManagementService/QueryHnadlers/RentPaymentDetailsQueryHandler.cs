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
    public class RentPaymentDetailsQueryHandler : IRequestHandler<RentPaymentDetailsQuery, RentPayment>
    {
        private readonly AppLeaseManagementDbContext _context;

        public RentPaymentDetailsQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<RentPayment> Handle(RentPaymentDetailsQuery request, CancellationToken cancellationToken)
        {
            var payment = _context.RentPayment.Include(l => l.Lease).ThenInclude(p => p.RentalProperty).FirstOrDefault(l => l.Id == request.Id);

            return payment;

            //throw new NotImplementedException();
        }
    }
}
