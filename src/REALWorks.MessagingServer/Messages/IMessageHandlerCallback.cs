using System.Threading.Tasks;

namespace REALWorks.MessagingServer.Messages
{
    public interface IMessageHandlerCallback
    {
        Task<bool> HandleMessageAsync(string messageType, string message);        
    }
}
