using infra.eventbus.commands;
using infra.eventbus.events;
using System.Threading.Tasks;

namespace infra.eventbus.interfaces
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() where T : Event
            where TH : IEventHandler<T>;

    }
}
