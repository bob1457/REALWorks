using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Events
{
    public class LeaseFinalizedEvent: Event
    {
        public readonly int RentalPropertyId;
        public readonly int ListingId;

        public LeaseFinalizedEvent(Guid messageId, int listingId,  int rentalPropertyId) : base(messageId)
        {
            RentalPropertyId = rentalPropertyId;
            ListingId = listingId;
        }
    }
}
