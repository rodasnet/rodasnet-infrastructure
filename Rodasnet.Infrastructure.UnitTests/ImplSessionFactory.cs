using Rodasnet.Infrastructure.Messaging;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplSessionFactory : AmqpSessionFactory
    {
        public override SessionConfiguration ConfigureSession()
        {
            return new SessionConfiguration
            {
                Policy = "Policy_Name",
                Key    = "00000000000000000",
                NamespaceUrl = "target.servicebus.rodasnet.net",
                Topic  = "Event_Or_Command",
                Link   = "Amqp_Link_Name"
            };
        }
    }
}
