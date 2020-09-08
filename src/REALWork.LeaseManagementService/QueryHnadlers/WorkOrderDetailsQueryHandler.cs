using MediatR;
using REALWork.LeaseManagementService.Queries;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class WorkOrderDetailsQueryHandler : IRequestHandler<WorkOrderDetailsQuery, WorkOrderDetailsViewModel>
    {
        public Task<WorkOrderDetailsViewModel> Handle(WorkOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
