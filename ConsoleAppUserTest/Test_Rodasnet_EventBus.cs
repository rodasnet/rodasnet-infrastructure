using Newtonsoft.Json;
using Rodasnet.Infrastructure.Messaging;
using Rodasnet.Infrastructure.Messaging.Factory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUserTest
{
    public class Test_Rodasnet_EventBus
    {
        public Test_Rodasnet_EventBus(ImplSenderSessionFactory sessionFactory)
        {
            var factory = new EventBusFactory();
            _eventBus = factory.CreateEventBus(sessionFactory);
        }

        private readonly IEventBusAsync _eventBus;

        public async Task RunAsync()
        {
            var a_event = new ImplEvent
            {
                SourceId = Guid.NewGuid(),
                PropEvent_1 = Guid.NewGuid()
            };

            // TODO: Use Rodasnet.Infrastructure EventBusAsync
            // try 
            await _eventBus.PublishAsync(a_event);

            Console.WriteLine("Sending IEvent a_event: {0}", a_event);

            // Old code to be deleted.

            //var JOps = new Newtonsoft.Json.JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //};

            //var serializedEvent = JsonConvert.SerializeObject(a_event, JOps);

            // TODO: move to IBus implementation
            // Message message = new Message(serializedEvent);

            //var sendSession = serviceBusSendSession.CreateSession();
            //SenderLink sender = new SenderLink(sendSession, "sender-link-bill-microservice", "new-bill-created-dev");
            //sender.Send(message);

            //Console.WriteLine("Serialized NewBillCreated: {0}", serializedEvent);
            //Console.WriteLine("Serialized NewBillCreated wrapped in AMQP Message: {0}", message.Body.ToString());
        }
    }
}
