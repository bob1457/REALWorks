using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Queries
{
    public class RentPaymentHistoryQuery : IRequest<IQueryable<RentPaymentHistoryViewModel>>// IRequest<IQueryable<RentPayment>> // use view model to get what needed
    {
        public int Id { get; set; }
        public int InChargeTenantId { get; set; }
    }
}
