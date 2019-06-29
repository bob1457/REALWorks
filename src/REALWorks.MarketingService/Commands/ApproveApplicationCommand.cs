using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalApplication;

namespace REALWorks.MarketingService.Commands
{
    public class ApproveApplicationCommand: IRequest
    {
        public int ApplicationId { get; set; }
        public ApplicationStatus AppStatus { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephone1 { get; set; }
        public string ContactTelephone2 { get; set; }
        public string ContactOthers { get; set; }
    }
}
