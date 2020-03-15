using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalApplication;

namespace REALWorks.MarketingService.ViewModels
{
    public class ApplicationListViewModel
    {
        public int RentalApplicationId { get; set; }
        public ApplicationStatus RentalApplicationStatus { get; set; }

        public string PropertyName { get; set; }


        public string ApplicatnFirstName { get; set; }
        public string ApplicatnLastName { get; set; }
        public string ApplicantContactTel { get; set; }
        public string ApplicantContactEmail { get; set; }
        public int ApplicantNubmerOfOccupants { get; set; }
        public string Notes { get; set; }
        public DateTime AppliedDate { get; set; }

    }
}
