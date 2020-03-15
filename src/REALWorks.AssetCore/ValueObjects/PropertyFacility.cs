using REALWorks.AssetCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.AssetCore.ValueObjects
{
    public class PropertyFacility: ValueObject
    {
        private PropertyFacility() { }

        public PropertyFacility(
            bool? stove, 
            bool? refrigerator, 
            bool? dishwasher,
            bool airConditioner, 
            bool? laundry, 
            bool? blindsCurtain, 
            bool furniture, 
            bool tvinternet, 
            bool commonFacility, 
            bool securitySystem, 
            bool utilityIncluded, 
            bool? fireAlarmSystem, 
            string others, 
            string notes)
        {
            Stove = stove;
            Refrigerator = refrigerator;
            Dishwasher = dishwasher;
            AirConditioner = airConditioner;
            Laundry = laundry;
            BlindsCurtain = blindsCurtain;
            Furniture = furniture;
            Tvinternet = tvinternet;
            CommonFacility = commonFacility;
            SecuritySystem = securitySystem;
            UtilityIncluded = utilityIncluded;
            FireAlarmSystem = fireAlarmSystem;
            Others = others;
            Notes = notes;
        }

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
