﻿using REALWorks.MarketingCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class RentalApplicantScoreCard: Entity
    {
        public int RentalApplicantId { get; private set; }

        public int ReferenceCheckScore { get; private set; }
        public int CreditCheckScore { get; private set; }
        public int IncomeCheckScore { get; private set; }
        public int OtherCheckScore { get; private set; }

        public string Notes { get; private set; }

        public RentalApplicant Applicant { get; private set; }
    }
}
