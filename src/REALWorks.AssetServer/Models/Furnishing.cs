using System;
using System.Collections.Generic;

namespace REALWorks.AssetServer.Models
{
    public partial class Furnishing
    {
        public int FurnishingId { get; set; }
        public int PropertyId { get; set; }
        public string FurnishingItemName { get; set; }
        public int FurnishingQuantity { get; set; }
        public string FurnishingConditions { get; set; }
        public string FurnishingCategory { get; set; }
        public string Notes { get; set; }
    }
}
