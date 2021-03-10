using System;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleAppUserTest
{
    public class MessageSenderAsync
    {
        // TODO: Move to configuration
        private const string Endpoint = "<service_bus>.servicebus.windows.net";

        private const string SasKeyName = "BillProcessManager";

        private const string SasKey = "00000000-0000-0000-0000-000000000000";

        private static readonly string EndpointUri = $"sb://{Endpoint}/";

        private static readonly string NamespaceConnectionString = $"Endpoint={EndpointUri};SharedAccessKeyName={SasKeyName};SharedAccessKey={SasKey}";

        private static readonly string WebSocketsNamespaceConnectionString = NamespaceConnectionString + ";TransportType=AmqpWebSockets";

        const string topic = "topic-name-dev";

        const string linkName = "my-sender-link-1";

        private readonly Amqp.Session _session;

        private readonly Amqp.SenderLink _sender;

        public MessageSenderAsync()
        {
            var connection = new Amqp.Connection(
                    new Amqp.Address(
                        // Create the AMQP connection string
                        $"amqps://{WebUtility.UrlEncode(SasKeyName)}:{WebUtility.UrlEncode(SasKey)}@{Endpoint}/"
                   )
                );

            _session = new Amqp.Session(connection);

            _sender = new Amqp.SenderLink(_session, linkName, topic);
        }

        public async Task SendAsync(Amqp.Message message)
        {
            await _sender.SendAsync(message);
            Console.WriteLine("Sending Message: {0}", message);
            Console.WriteLine("Sending Message wrapped in AMQP Message: {0}", message.Body.ToString());
        }
    }
}
