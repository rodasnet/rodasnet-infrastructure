namespace Rodasnet.Infrastructure.Processes
{
    using System.Threading.Tasks;
    using Rodasnet.Infrastructure.Messaging;
    using Rodasnet.Infrastructure.Messaging.Handling;
    using System.Text;
    using System;
    using Amqp;

    public abstract class AbstractProcessorAsync<T> : IProcessorAsync where T : IEvent
    {
        private readonly IEventHandlerAsync<T>  _router;

        private readonly AmqpSessionFactory _sessionFactory;

        public AbstractProcessorAsync(
            AmqpSessionFactory factory, 
            IEventHandlerAsync<T> handler
            )
        {          
            _router = handler;
            _sessionFactory = factory;
        }
        
        protected abstract T Deserialize(string data);

        public async Task StartAsync()
        {
            try
            {
                Console.WriteLine("Start receiving ...");
                var session = _sessionFactory.CreateSession();
                ReceiverLink receiver = new ReceiverLink(session, _sessionFactory.LinkName, _sessionFactory.Topic);
 
                using (Amqp.Message message = await receiver.ReceiveAsync())
                {
                    if (message != null)
                    {
                        var rawBody = message.Body;
                        string stringBody;
                        Console.WriteLine("Type of Body is: {0}.", rawBody.GetType());
                        // If the body is byte[] assume it was sent as a BrokeredMessage  
                        if (rawBody is byte[] BodyAsByteArray)
                        {
                            Console.WriteLine("Message body came back as byte array.");
                            stringBody = Encoding.UTF8.GetString(BodyAsByteArray).ToCharArray().ToString();
                        }
                        else if (rawBody is String)
                        {
                            Console.WriteLine("Body came in as String.");
                            stringBody = rawBody.ToString();
                        }
                        else
                        {
                            Console.WriteLine("Message was rejected because body was neither String nor byte[]: ");
                            receiver.Reject(message);
                            await session.CloseAsync();
                            return;
                        }

                        var i_event = Deserialize(stringBody); Console.WriteLine("Deserialized Message: {0}.", i_event.ToString());

                        await _router.HandleAsync(i_event);

                        receiver.Accept(message);
                    }
                }

                await session.CloseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                Console.WriteLine("Message Rejected from queue because there was a problem saving to microservice database");
            }
        }

        public virtual async Task StopAsync()
        {
            await Task.Delay(100);
        }
    }
}

