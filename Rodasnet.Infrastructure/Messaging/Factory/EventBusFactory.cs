using System;
using System.Collections.Generic;
using System.Text;

namespace Rodasnet.Infrastructure.Messaging.Factory
{
    public class EventBusFactory
    {

        public IEventBusAsync CreateEventBus(AmqpSessionFactory sessionFactory) => new EventBusAsync(new MessageSenderAsync(sessionFactory));
    }
}
