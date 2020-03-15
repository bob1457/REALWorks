using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace REALWork.LeaseManagementService.Queries
{
    public class RentalDetailsForReportingQuery: IRequest<Lease>
    {
        public int LeaseId { get; set; }
        public int InChargeTenantId { get; set; }
    }
}
