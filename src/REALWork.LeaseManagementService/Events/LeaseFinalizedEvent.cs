using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Events
{
    public class LeaseFinalizedEvent: Event
    {
        public readonly int RentalPropertyId;
        public readonly int ListingId;

        public LeaseFinalizedEvent(Guid messageId, int rentalPropertyId, int listingId) : base(messageId)
        {
            RentalPropertyId = rentalPropertyId;
            ListingId = listingId;
        }
    }
}
