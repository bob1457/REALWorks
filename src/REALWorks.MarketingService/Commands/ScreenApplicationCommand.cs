using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Commands
{
    public class ScreenApplicationCommand : IRequest<string>
    {
        public int RentalApplicationId { get; set; }
        public int ReferenceCheckScore { get; set; }
        public int CreditCheckScore { get; set; }
        public int IncomeCheckScore { get; set; }
        public int OtherCheckScore { get; set; }

        public string Notes { get; set; }
    }
}
