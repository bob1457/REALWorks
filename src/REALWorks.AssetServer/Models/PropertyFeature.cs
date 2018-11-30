using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class PropertyFeature
    {
        public PropertyFeature()
        {
            Property = new HashSet<Property>();
        }

        public int PropertyFeatureId { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfLayers { get; set; }
        public int NumberOfParking { get; set; }
        public bool BasementAvailable { get; set; }
        public int TotalLivingArea { get; set; }
        public bool IsShared { get; set; }
        public string Notes { get; set; }

        public ICollection<Property> Property { get; set; }
    }
}
