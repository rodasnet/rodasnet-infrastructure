using Amqp;
using Amqp.Framing;
using Amqp.Handler;
using Amqp.Sasl;

namespace Rodasnet.Infrastructure.Messaging
{
    public class Connection : Amqp.Connection
    {
        public Connection(Address address) : base(address)
        {
        }

        public Connection(Address address, IHandler handler) : base(address, handler)
        {
        }

        public Connection(Address address, SaslProfile saslProfile, Open open, OnOpened onOpened) : base(address, saslProfile, open, onOpened)
        {
        }
    }
}
