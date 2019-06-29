using REALWorks.InfrastructureServer.MessageLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.InfrastructureServer.MessageLog
{
    public interface IMessageLoggingService
    {
        Task LogMessage(Message msg);
        Task<IEnumerable<Message>> GetMessages();
    }

     

}
