using System;
using System.Collections.Generic;
using System.Text;

namespace REALWorks.MessagingServer.Messages
{
    public interface IMessageHandler
    {
        void Start(IMessageHandlerCallback callback);
        void Stop();
    }
}
