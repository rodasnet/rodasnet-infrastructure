using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rodasnet.Infrastructure.Messaging
{
    public class EventBusAsync : IEventBusAsync
    {
        private readonly IMessageSenderAsync sender;
        //private readonly IMetadataProvider metadataProvider;
        //private readonly ITextSerializer serializer;

        public EventBusAsync(IMessageSenderAsync sender)
        {
            this.sender = sender;
        }

        public async Task PublishAsync(Envelope<IEvent> @event)
        {
            string serializedEvent = JsonSerializer.Serialize(@event);
            Console.WriteLine($"Publishing serialized event: {serializedEvent}");
            Message message = new Message(serializedEvent);
            // What is the Envelope for?
            await sender.SendAsync(message);
        }

        public Task PublishAsync(IEnumerable<Envelope<IEvent>> events)
        {
            throw new NotImplementedException();
        }
    }
}
