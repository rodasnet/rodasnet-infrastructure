namespace Rodasnet.Infrastructure.Processes
{
    using System.Threading.Tasks;
    using Rodasnet.Infrastructure.Messaging;
    using Rodasnet.Infrastructure.Messaging.Handling;
    using System.Text;
    using System;
    using Amqp;

    /// <summary>
    /// Abstaract class implemented by process managers that use AMQP (also known as Sagas in the CQRS community) to 
    /// publish commands to the command bus.
    /// </summary>
    /// <remarks>
    /// <para>See <see cref="http://go.microsoft.com/fwlink/p/?LinkID=258564">Reference 6</see> for a description of what is a Process Manager.</para>
    /// <para>There are a few things that we learnt along the way regarding Process Managers, which we might do differently with the new insights that we
    /// now have. See <see cref="http://go.microsoft.com/fwlink/p/?LinkID=258558"> Journey lessons learnt</see> for more information.</para>
    /// </remarks>
    public abstract class MicroserviceProcessManager<T> where T : ICommand
    {
        /*** SHould I mak this a List of ICommand Handlers or should I jsut omit this?? ***/
        
        protected ICommandHandlerAsync<T> _commandHandler;

        private readonly AmqpSessionFactory _sessionFactory;

        public MicroserviceProcessManager(
            AmqpSessionFactory factory,
            ICommandHandlerAsync<T> commandHandlerImp
            )
        {
            _sessionFactory = factory;
            _commandHandler = commandHandlerImp;
        }

        protected abstract T Deserialize(string data);

        public async Task ReceiveCommandAsync()
        {
            try
            {
                Console.WriteLine("Start receiving commands ...");
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

                        var i_command = Deserialize(stringBody); Console.WriteLine("Deserialized Message: {0}.", i_command.ToString());

                        await _commandHandler.HandleAsync(i_command);

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
    }
}
