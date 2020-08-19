using REALWorks.MarketingCore.Base;
using REALWorks.MarketingCore.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MarketingCore.Entities
{
    public class OpenHouse: Entity
    {
        
        private OpenHouse()
        {
            OpenHouseViewer = new HashSet<OpenHouseViewer>();
        }

        public OpenHouse(int rentalPropertyId, DateTime openhouseDate, 
            string startTime, string endTime, bool isActive, string notes,
            DateTime created, DateTime updated)
        {
            RentalPropertyId = rentalPropertyId;
            OpenhouseDate = openhouseDate;
            StartTime = startTime;
            EndTime = endTime;
            IsActive = isActive;
            Notes = notes;
            Created = created;
            Modified = updated;
        }

        public int RentalPropertyId { get; private set; }
        public DateTime OpenhouseDate { get; private set; }
        public bool IsActive { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public string Notes { get; private set; }

        public RentalProperty RentalProperty { get; private set; }
        public ICollection<OpenHouseViewer> OpenHouseViewer { get; private set; }


        // Behaviors
        public OpenHouse Update(OpenHouse openHouse, DateTime date, 
            bool isActive, string startTime, string endTime, 
            string notes)
        {
            openHouse.OpenhouseDate = date;
            openHouse.IsActive = isActive;
            openHouse.StartTime = startTime;
            openHouse.EndTime = endTime;
            openHouse.Notes = notes;

            return this;
        }

    }
}
