using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.Asset.Api.Model
{
    public class ManagementContract
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string PropertyId { get; set; }
        public string ContractTitle { get; set; }
        public string ConttactDesc { get; set; }
        public string ClientName { get; set; }
        public string ManagerName { get; set; }
        public bool isActive { get; set; }
        public string DocumentUrl { get; set; }
        public string Notes { get; set; }

        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime SignedDate { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
