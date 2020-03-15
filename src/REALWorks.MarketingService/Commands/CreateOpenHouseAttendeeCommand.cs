using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.OpenHouseViewer;

namespace REALWorks.MarketingService.Commands
{
    public class CreateOpenHouseAttendeeCommand : IRequest<bool>
    {
        public int OpenHouseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSms { get; set; }
        public string ContactOthers { get; set; }
        public int? NumberOfPeople { get; set; }
        public PreferredContact ContactType {get; set;}
    }
}
