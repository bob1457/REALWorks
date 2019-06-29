using System.Threading.Tasks;

namespace REALWorks.MessagingServer.EventBus
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}