namespace Rodasnet.Infrastructure.Messaging
{
    public class Message : Amqp.Message
    {
        public Message() : base() { }

        public Message(object body) : base(body) { }
    }
}
