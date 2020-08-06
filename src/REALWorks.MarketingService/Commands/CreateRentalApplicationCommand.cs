using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalApplicant;
using static REALWorks.MarketingCore.Entities.RentalApplication;

namespace REALWorks.MarketingService.Commands
{
    public class CreateRentalApplicationCommand: IRequest<bool>
    {
        public int RentalPropertyId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSms { get; set; }
        public string ContactOthers { get; set; }
        public int? AnnualIncome { get; set; }
        public int NumberOfOccupant { get; set; }
        public bool? WithChildren { get; set; }
        public LegalStatus Status { get; set; }
        public ApplicationStatus AppStatus { get; set; }
        public string CreditRating { get; set; }
        public string EmpoyedStatus { get; set; }
        public int RentalApplicationId { get; set; }
        public string ReasonToMove { get; set; }

        public int NotificaitonType { get; set; }


    }
}
