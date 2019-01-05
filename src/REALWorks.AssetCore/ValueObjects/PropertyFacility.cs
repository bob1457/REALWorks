using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.ValueObjects
{
    public class PropertyFacility: ValueObject
    {
        public bool? Stove { get; set; }
        public bool? Refrigerator { get; set; }
        public bool? Dishwasher { get; set; }
        public bool AirConditioner { get; set; }
        public bool? Laundry { get; set; }
        public bool? BlindsCurtain { get; set; }
        public bool Furniture { get; set; }
        public bool Tvinternet { get; set; }
        public bool CommonFacility { get; set; }
        public bool SecuritySystem { get; set; }
        public bool UtilityIncluded { get; set; }
        public bool? FireAlarmSystem { get; set; }
        public string Others { get; set; }
        public string Notes { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
