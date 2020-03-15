using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.InfrastructureServer.MessageLog
{
    public class MessageLoggingService : IMessageLoggingService
    {
        private readonly IMessageContext _context;

        public MessageLoggingService(IMessageContext context)
        {
            _context = context;
        }

        public MessageLoggingService()
        {
        }

        public async Task LogMessage(Message msg)
        {
            //throw new NotImplementedException();           

            await _context.Messages.InsertOneAsync(msg);
        }

        
        public async Task<IEnumerable<Message>> GetMessages()
        {
            //throw new NotImplementedException();
            var result = _context.Messages.AsQueryable();

            return await result.ToListAsync();

        }
    }
}
