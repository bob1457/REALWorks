using MediatR;
using REALWorks.AssetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class FeePaymentHistoryQuery: IRequest<IQueryable<FeePayment>>
    {
        public int ManagementContractId { get; set; }
        public int InChargeOwnerId { get; set; }
    }
}
