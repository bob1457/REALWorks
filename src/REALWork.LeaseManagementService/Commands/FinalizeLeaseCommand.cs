using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class FinalizeLeaseCommand: IRequest<Unit>
    {
        public int LeaseId { get; set; }
        public DateTime LeaseSignDate { get; set; }
    }
}
