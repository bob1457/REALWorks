using REALWork.LeaseManagementCore.Entities;
using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class RentCoverage : ValueObject
    {
        private RentCoverage()
        {
        }

        public RentCoverage(bool water, bool cablevison, bool electricity, 
            bool internet, bool heat, bool naturalGas, bool sewageDisposal, bool snowRemoval, 
            bool storage, bool recreationFacility, bool garbageCollection, bool recycleServices, 
            bool kitchenScrapCollection, bool laundry, /*bool freeLaundry,*/ bool refrigerator, 
            bool dishwasher, bool stoveOven, bool windowCovering, bool furniture, bool carpets, 
            int parkingStall, string other)
        {            
            Water = water;
            Cablevison = cablevison;
            Electricity = electricity;
            Internet = internet;
            Heat = heat;
            NaturalGas = naturalGas;
            SewageDisposal = sewageDisposal;
            SnowRemoval = snowRemoval;
            Storage = storage;
            RecreationFacility = recreationFacility;
            GarbageCollection = garbageCollection;
            RecycleServices = recycleServices;
            KitchenScrapCollection = kitchenScrapCollection;
            Laundry = laundry;
            //FreeLaundry = freeLaundry;
            Regigerator = refrigerator;
            Dishwasher = dishwasher;
            StoveOven = stoveOven;
            WindowCovering = windowCovering;
            Furniture = furniture;
            Carpets = carpets;
            ParkingStall = parkingStall;
            Other = other;
        }

        public int LeaseId { get; private set; }
        public bool Water { get; private set; }
        public bool Cablevison { get; private set; }
        public bool Electricity { get; private set; }
        public bool Internet { get; private set; }
        public bool Heat { get; private set; }
        public bool NaturalGas { get; private set; }
        public bool SewageDisposal { get; private set; }
        public bool SnowRemoval { get; private set; }
        public bool Storage { get; private set; }
        public bool RecreationFacility { get; private set; }
        public bool GarbageCollection { get; private set; }
        public bool RecycleServices { get; private set; }
        public bool KitchenScrapCollection { get; private set; }
        public bool Laundry { get; private set; }
        //public bool FreeLaundry { get; private set; }
        public bool Regigerator { get; private set; }
        public bool Dishwasher { get; private set; }
        public bool StoveOven { get; private set; }
        public bool WindowCovering { get; private set; }
        public bool Furniture { get; private set; }
        public bool Carpets { get; private set; }
        public int ParkingStall { get; private set; }
        public string Other { get; private set; }

        public Lease Lease { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            //throw new NotImplementedException();
            yield return Other;
        }
    }
}
