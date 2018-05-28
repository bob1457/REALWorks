﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public class Owner
    {
        //[BsonId] // standard BSonId generated by MongoDb ---- There is NO need to have an Id for this single embedded document inside the Property object
        //public ObjectId Id { get; set; }

        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string City { get; set; }
        public string ProvinceState { get; set; }
        public string PostZipCode { get; set; }
        public string Country { get; set; }

        public string ContactTelephone { get; set; }
        public string ContactEmail { get; set; }
    }
}