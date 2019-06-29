using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Queries
{
    public class RentPaymentDetailsQuery : IRequest<RentPayment>
    {
        public int Id { get; set; }
    }
}
