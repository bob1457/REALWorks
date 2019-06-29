using REALWorks.LeaseManagementCore.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace REALWork.LeaseManagementCore.Entities
{
    public class Agent: Entity
    {
        private Agent()
        {
        }

        public Agent(string firstName, string lastName, 
            string contactEmial, string contztTel, string contactOthers, 
            bool isPropertyManager, string addressStreetNumber, string addressCity, 
            string addressStateProv, string addressZipPostCode, string addressCountry)
        {            
            FirstName = firstName;
            LastName = lastName;
            ContactEmial = contactEmial;
            ContztTel = contztTel;
            ContactOthers = contactOthers;
            IsPropertyManager = isPropertyManager;
            AddressStreetNumber = addressStreetNumber;
            AddressCity = addressCity;
            AddressStateProv = addressStateProv;
            AddressZipPostCode = addressZipPostCode;
            AddressCountry = addressCountry;
        }

        public int LeaseId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ContactEmial { get; private set; }
        public string ContztTel { get; private set; }
        public string ContactOthers { get; private set; }
        public bool IsPropertyManager { get; private set; }
        public string AddressStreetNumber { get; private set; }
        public string AddressCity { get; private set; }
        public string AddressStateProv { get; private set; }
        public string AddressZipPostCode { get; private set; }
        public string AddressCountry { get; private set; }

        public Lease Lease { get; private set; }
    }
}
