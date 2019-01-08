using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.ValueObjects
{
    public class PropertyFeature : ValueObject
    {
        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }

        private PropertyFeature() { }

        public PropertyFeature(
            int numberOfBedrooms, 
            int numberOfBathrooms, 
            int numberOfLayers, 
            int numberOfParking, 
            bool basementAvailable, 
            int totalLivingArea, 
            bool isShared, 
            string notes)
        {
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            NumberOfLayers = numberOfLayers;
            NumberOfParking = numberOfParking;
            BasementAvailable = basementAvailable;
            TotalLivingArea = totalLivingArea;
            IsShared = isShared;
            Notes = notes;
        }

        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfLayers { get; set; }
        public int NumberOfParking { get; set; }
        public bool BasementAvailable { get; set; }
        public int TotalLivingArea { get; set; }
        public bool IsShared { get; set; }
        public string Notes { get; set; }
    }
}
