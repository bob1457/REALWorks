using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace REALWorks.MessagingServer.Messages
{
    public interface IMessagePublisher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="message"></param>
        /// <param name="routingKey"></param>
        /// <returns></returns>
        Task PublishMessageAsync(string messageType, object message, string routingKey);
    }
}
