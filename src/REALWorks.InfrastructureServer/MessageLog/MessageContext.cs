using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace REALWorks.InfrastructureServer.MessageLog
{
    public class MessageContext : IMessageContext
    {
        private readonly IMongoDatabase _db;

        public MessageContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);

            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Message> Messages => _db.GetCollection<Message>("Messages");
    }
}
