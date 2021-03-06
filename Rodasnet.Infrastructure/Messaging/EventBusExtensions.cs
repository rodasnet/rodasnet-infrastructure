using System.Collections.Generic;
using System.Linq;

namespace Rodasnet.Infrastructure.Messaging
{
    public static class EventBusExtensions
    {
        public static void Publish(this IEventBus bus, IEvent @event)
        {
            bus.Publish(new Envelope<IEvent>(@event));
        }

        public static void Publish(this IEventBus bus, IEnumerable<IEvent> events)
        {
            bus.Publish(events.Select(x => new Envelope<IEvent>(x)));
        }
    }
}
