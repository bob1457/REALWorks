using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.InfrastructureServer.MessageLog
{
    public class Message
    {
        public Message(Guid messageId, string serviceName, BsonDocument payload, 
            string queue, string routingkey, string action, DateTime created)
        {
            MessageId = messageId;
            ServiceName = serviceName;
            Payload = payload;
            Queue = queue;
            Routingkey = routingkey;
            Action = action;
            Created = created;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //Additional field for application generated message id
        [BsonElement("MessageId")]
        public Guid MessageId { get; set; }

        [BsonElement("ServiceName")]
        public string ServiceName { get; set; }

        //[BsonElement("Payload")]
        //public string Payload { get; set; }
        public BsonDocument Payload { get; set; }

        [BsonElement("Queue")]
        public string Queue { get; set; }

        [BsonElement("Routingkey")]
        public string Routingkey { get; set; }

        [BsonElement("Action")]
        public string Action { get; set; } // Publish/Subscribe

        [BsonElement("Created")]
        public DateTime Created { get; set; }

    }
}
