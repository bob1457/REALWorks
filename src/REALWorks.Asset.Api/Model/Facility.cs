using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public class Facility
    {
        public bool Fridgerator { get; set; }
        public bool StoreOven { get; set; }
        public bool WindowsDrappers { get; set; }
        public bool TVCable { get; set; }
        public bool Internet { get; set; }
        public bool SecurityAlarm { get; set; }
        public bool SmokeDetector { get; set; }
        public bool CommonArea { get; set; }
        public bool WasherDryer { get; set; }

        public string Notes { get; set; }
    }
}
