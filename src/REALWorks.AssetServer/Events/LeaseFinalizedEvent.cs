using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Events
{
    public class LeaseFinalizedEvent: Event
    {
        public readonly int RentalPropertyId;

        public LeaseFinalizedEvent(Guid messageId, int rentalPropertyId) : base(messageId)
        {
            RentalPropertyId = rentalPropertyId;
        }
    }
}
