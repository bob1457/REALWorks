using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class AddInspectionReportToLeaseCommandHandler : IRequestHandler<AddInspectionReportToLeaseCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;
        private readonly IMediator mediator;

        public AddInspectionReportToLeaseCommandHandler(AppLeaseManagementDbContext context, IMediator _mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public Task<Unit> Handle(AddInspectionReportToLeaseCommand request, CancellationToken cancellationToken)
        {



            return Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
