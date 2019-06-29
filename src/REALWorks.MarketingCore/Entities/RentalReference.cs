using REALWorks.MarketingCore.Base;

namespace REALWorks.MarketingCore.Entities
{
    public class RentalReference: Entity
    {
        private RentalReference()
        {
        }

        public enum ContactType
        {
            NotSet,
            PreLandloard,
            CurLandlord,
            Employer,
            Other
        }

        public RentalReference(int rentalApplicatId, string contactName, 
            string contactTel, string contactEmail, ContactType contactType, 
            RentalApplicant rentalApplicant)
        {
            RentalApplicatId = rentalApplicatId;
            ContactName = contactName;
            ContactTel = contactTel;
            ContactEmail = contactEmail;
            Type = contactType;
            RentalApplicant = rentalApplicant;
        }

        public int RentalApplicatId { get; private set; }
        public string ContactName { get; private set; }
        public string ContactTel { get; private set; }
        public string ContactEmail { get; private set; }
        public ContactType Type { get; private set; }

        public RentalApplicant RentalApplicant { get; private set; }
    }
}