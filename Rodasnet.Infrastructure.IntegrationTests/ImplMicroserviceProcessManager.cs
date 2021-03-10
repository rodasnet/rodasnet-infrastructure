using Newtonsoft.Json;
using Rodasnet.Infrastructure.Messaging;
using Rodasnet.Infrastructure.Messaging.Handling;
using Rodasnet.Infrastructure.Processes;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    class ImplMicroserviceProcessManager : MicroserviceProcessManager<ImplCommand>
    {
        public ImplMicroserviceProcessManager(
            AmqpSessionFactory factory,
            ICommandHandlerAsync<ImplCommand> commandHandler)
            : base(factory, commandHandler)
        { }

        protected override ImplCommand Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<ImplCommand>(data);
        }

        public ImplCommand TestDeserializer(string data)
        {
            return Deserialize(data);
        }
    }
}
