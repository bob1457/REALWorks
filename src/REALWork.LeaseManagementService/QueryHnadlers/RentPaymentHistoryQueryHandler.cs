using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class RentPaymentHistoryQueryHandler : IRequestHandler<RentPaymentHistoryQuery, IQueryable<RentPaymentHistoryViewModel>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public RentPaymentHistoryQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<RentPaymentHistoryViewModel>> Handle(RentPaymentHistoryQuery request, CancellationToken cancellationToken)
        {
            //var rentPaymentHistory = _context.RentPayment.Include(l => l.Lease).ThenInclude(p => p.RentalProperty).ToList();

            //return rentPaymentHistory.AsQueryable();

            var rentPaymentHistory = from rent in _context.RentPayment
                                     join lease in _context.Lease on rent.LeaseId equals lease.Id
                                     join tenant in _context.Tenant on lease.Id equals tenant.LeaseId
                                     
                                     //join lease2 in _context.Lease on rent.LeaseId equals lease2.Id                                     
                                     join property in _context.RentalProperty on lease.RentalPropertyId equals property.Id
                                     where lease.Id == request.Id && tenant.Id == request.InChargeTenantId
                                      //from lease in _context.Lease
                                      select new RentPaymentHistoryViewModel
                                      {
                                          LeaseTitle = lease.LeaseTitle,
                                          Id = rent.Id,
                                          LeaseId = lease.Id,
                                          PropertyName = property.PropertyName,

                                          FirstName = tenant.FirstName,
                                          LastName = tenant.LastName,
                                          ContactTelephone1 = tenant.ContactTelephone1,
                                          ContactEmail = tenant.ContactEmail,

                                          ScheduledPaymentAmt = rent.ScheduledPaymentAmt,
                                          ActualPaymentAmt = rent.ActualPaymentAmt,
                                          RentalForMonth = rent.RentalForMonth,
                                          RentalForYear = rent.RentalForYear,
                                          PaymentDueDate = rent.PaymentDueDate,
                                          PaymentReceivedDate = rent.PaymentReceivedDate,
                                          PayMethod = rent.PayMethod
                                      };

            return rentPaymentHistory.AsQueryable();


            //throw new NotImplementedException();
        }
    }
}
