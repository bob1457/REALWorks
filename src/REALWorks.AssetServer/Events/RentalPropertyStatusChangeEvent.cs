using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Events
{
    public class RentalPropertyStatusChangeEvent : Event
    {
        public readonly int OriginalPropertyId;
        public readonly string CurrentStatus;

        public RentalPropertyStatusChangeEvent(Guid messageId, int originalPropertyId, string currentStatus) : base(messageId)
        {
            OriginalPropertyId = originalPropertyId;
            CurrentStatus = currentStatus;
        }
    }
}
