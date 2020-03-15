using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class FeePaymentHistoryQueryHandler : IRequestHandler<FeePaymentHistoryQuery, IQueryable<FeePayment>>
    {
        private readonly AppDataBaseContext _context;

        public FeePaymentHistoryQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<FeePayment>> Handle(FeePaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            var feePaymentList = _context.FeePayment
                .Where(m => m.ManagementContractId == request.ManagementContractId)
                .Include(c => c.Contract)
                .ThenInclude(p => p.Property)
                .AsQueryable();

            return feePaymentList;

            //throw new NotImplementedException();
        }
    }
}
