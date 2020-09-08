using MediatR;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Queries
{
    public class WorkOrderDetailsQuery : IRequest<WorkOrderDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
