using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public class Feature
    {
        public string NumOfBedrooms { get; set; }
        public string NumOfBathrooms { get; set; }
        public string NumOfParking { get; set; }
        public string TotalArea { get; set; }
        public string NumOflayers { get; set; }
        public bool IsBasement { get; set; }
        public bool IsShared { get; set; }
        public string Others { get; set; }

        public string Notes { get; set; }
    }
}
