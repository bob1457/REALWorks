﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public class Property: BaseModel
    {
        //[BsonId] // standard BSonId generated by MongoDb
        //public ObjectId Id { get; set; }        

        public string PropertyName { get; set; }
        public string PropertyDesc { get; set; }
        public int YearBuilt { get; set; }
        public string Category { get; set; }
        public bool isActive { get; set; }
        public string Status { get; set; }

        public Address PropertyAddress { get; set; }
        public Facility PropertyFacility { get; set; }
        public Feature PropertyFeature { get; set; }

        public List<string> PropertyOwners { get; set; } // only contains owner Id, no detailed data for owner
        //public Owner PropertyOwner { get; set; }

        public List<Tenant> PropertyTenants { get; set; }
        //[BsonIgnore]
        //public Tenant [] TenantList { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
