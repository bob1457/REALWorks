using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalApplicant;

namespace REALWorks.MarketingService.ViewModels
{
    public class ApplicationDetailsViewModel
    {
        public string PropertyName { get; set; }
        public string ApplicatnFirstName { get; set; }
        public string ApplicatnLastName { get; set; }
        public string ApplicantContactTel { get; set; }
        public string ApplicantContactEmail { get; set; }
        public int ApplicantNubmerOfOccupants { get; set; }
        public string ContactSms { get; set; }
        public string ContactOthers { get; set; }
        public int? AnnualIncome { get; set; }
        public int NumberOfOccupant { get; set; }
        public bool? WithChildren { get; set; }
        public LegalStatus Status { get; set; }
        public string CreditRating { get; set; }
        public string EmpoyedStatus { get; set; }
        public int RentalApplicationId { get; set; }
        public string ReasonToMove { get; set; }
        public bool WithCoApplicant { get; set; }
        public string Notes { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
