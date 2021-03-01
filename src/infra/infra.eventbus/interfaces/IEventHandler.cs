using infra.eventbus.events;
using System.Threading.Tasks;

namespace infra.eventbus.interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        Task<bool> Handle(TEvent @event);

    }

    public interface IEventHandler { }
}
