﻿using MediatR;
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
    public class LeaseDetailsQueryHandler : IRequestHandler<LeaseDetailsQuery, Lease>
    {
        private readonly AppLeaseManagementDbContext _context;

        public LeaseDetailsQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Lease> Handle(LeaseDetailsQuery request, CancellationToken cancellationToken) // need to refactor the query using view model
        {
            var lease = _context.Lease
                //.Include(p => p.RentalProperty).ThenInclude(a => a.Address)
                .Include(l => l.RentalProperty).ThenInclude(p => p.RentalPropertyOwners)
                .Include(a => a.Agent)
                .Include(l => l.RentPayment) // considering not inlcuded here, instead use a separate process
                .Include(t => t.Tenant).ToList();

            //var rentalProperty = _context.RentalProperty
            //    .Include(p => p.Address)
            //    .Include(p => p.RentalPropertyOwners).ToList();




            //throw new NotImplementedException();

            return lease.FirstOrDefault(l => l.Id == request.Id);
        }
    }
}
