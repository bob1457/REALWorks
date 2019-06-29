using REALWorks.MarketingCore.Base;
using System;
using System.Collections.Generic;

namespace REALWorks.MarketingCore.Entities
{
    public class RentalApplicant: Entity
    {
        private RentalApplicant()
        {
            
        }

        public enum LegalStatus
        {
            NotSet,
            Citizen,
            Landed,
            Visa,
            Other
        }

        public RentalApplicant(string firstName, string lastName, string contactTel, 
            string contactEmail, string contactSms, string contactOthers, int? annualIncome, int numberOfOccupant, 
            bool? withChildren, LegalStatus legalStatus, string empoyedStatus, string reasonToMove,   DateTime created, DateTime updated )
        {
            FirstName = firstName;
            LastName = lastName;
            ContactTel = contactTel;
            ContactEmail = contactEmail;
            ContactSms = contactSms;
            ContactOthers = contactOthers;
            AnnualIncome = annualIncome;
            NumberOfOccupant = numberOfOccupant;
            WithChildren = withChildren;
            Status = legalStatus;
            EmpoyedStatus = empoyedStatus;            
            ReasonToMove = reasonToMove;
            Created = created;
            Modified = updated;
        }
                
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactTel { get; private set; }
        public string ContactEmail { get; private set; }
        public string ContactSms { get; private set; }
        public string ContactOthers { get; private set; }
        public int? AnnualIncome { get; private set; }
        public int NumberOfOccupant { get; private set; }
        public bool? WithChildren { get; private set; }
        public LegalStatus Status { get; private set; }
        public string CreditRating { get; private set; }
        public string EmpoyedStatus { get; private set; }
        public int RentalApplicationId { get; private set; }
        public string ReasonToMove { get; private set; }
        public bool WithCoApplicant { get; private set; }
        


        public RentalApplication RentalApplication { get; private set; }
        public RentalApplicantScoreCard ApplicantScoreCard { get; private set; }
        public ICollection<RentalReference> RentalReference { get; private set; }
    }
}