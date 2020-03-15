using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.ValueObjects
{
    public class KeyAndControl : ValueObject
    {        
        private KeyAndControl()
        {
        }

        public KeyAndControl(string entranceKeysIssued, string entranceKeysReturned, bool unitKeysIssed, 
            bool unitKeysReturned, bool eUnitDeadlocksIssed, bool eUnitDeadlocksReturned, bool parkingRemoteControlIssed, 
            bool parkingRemoteControlReturned)
        {
            EntranceKeysIssued = entranceKeysIssued;
            EntranceKeysReturned = entranceKeysReturned;
            UnitKeysIssed = unitKeysIssed;
            UnitKeysReturned = unitKeysReturned;
            EUnitDeadlocksIssed = eUnitDeadlocksIssed;
            EUnitDeadlocksReturned = eUnitDeadlocksReturned;
            ParkingRemoteControlIssed = parkingRemoteControlIssed;
            ParkingRemoteControlReturned = parkingRemoteControlReturned;
        }

        public string EntranceKeysIssued { get; private set; }
        public string EntranceKeysReturned { get; private set; }
        
        public bool UnitKeysIssed { get; private set; }
        public bool UnitKeysReturned { get; private set; }        
        
        public bool EUnitDeadlocksIssed { get; private set; }
        public bool EUnitDeadlocksReturned { get; private set; }
        
        public bool ParkingRemoteControlIssed { get; private set; }
        public bool ParkingRemoteControlReturned { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
