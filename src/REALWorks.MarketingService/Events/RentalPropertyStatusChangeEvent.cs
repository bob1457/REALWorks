using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.Events
{
    public class RentalPropertyStatusChangeEvent : Event
    {

        public readonly int OriginalPropertyId;
        public readonly string CurrentStatus; //public readonly ListingStatus CurrentStatus;

        public RentalPropertyStatusChangeEvent(Guid messageId, int originalPropertyId, string currentStatus) : base(messageId)
        {
            OriginalPropertyId = originalPropertyId;
            CurrentStatus = currentStatus;
        }
    }
}
