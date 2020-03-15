using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public class PropertyImage:BaseModel
    {
        //[BsonId]
        //public ObjectId Id { get; set; }

        public string PropertyId { get; set; }
        public string Caption { get; set; }
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
