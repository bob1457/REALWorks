using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateRentalPropertyStatusCommand: IRequest<Unit>
    {
        public int LeaseId { get; set; }
        public string RentalPropertyStatus { get; set; }
    }
}
