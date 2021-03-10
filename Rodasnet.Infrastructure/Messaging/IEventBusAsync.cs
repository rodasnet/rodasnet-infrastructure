namespace Rodasnet.Infrastructure.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// An event bus that sends serialized object payloads.
    /// </summary>
    /// <remarks>Note that <see cref="Infrastructure.EventSourcing.IEventSourced"/> entities persisted through 
    /// the <see cref="Infrastructure.EventSourcing.IEventSourcedRepository{T}"/> do not
    /// use the <see cref="IEventBus"/>, but has its own event publishing mechanism.</remarks>
    public interface IEventBusAsync
    {
        Task PublishAsync(Envelope<IEvent> @event);

        Task PublishAsync(IEnumerable<Envelope<IEvent>> events);
    }
}
