using Amqp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.Messaging
{
    public class MessageSenderAsync : IMessageSenderAsync
    {
        public event EventHandler Retrying;

        private readonly AmqpSessionFactory _sessionFactory;

        public MessageSenderAsync(AmqpSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task SendAsync(Message message)
        {
            try
            {
                Console.WriteLine("SendAsync begin transaction ...");
                var session = _sessionFactory.CreateSession();

                SenderLink sender = new SenderLink(session, _sessionFactory.LinkName, _sessionFactory.Topic);
                
                await sender.SendAsync(message);

                await session.CloseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                Console.WriteLine("Could not send Message.");
            }
        }

        public Task SendAsync(Message message, Action successCallback, Action<Exception> exceptionCallback)
        {
            throw new NotImplementedException();
        }
    }
}
