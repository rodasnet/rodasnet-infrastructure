using Newtonsoft.Json;
using Rodasnet.Infrastructure.Messaging;
using Rodasnet.Infrastructure.Messaging.Handling;
using Rodasnet.Infrastructure.Processes;
using System;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.UnitTests
{
    class ImplMicroserviceProcessManager_2 : MicroserviceProcessManager<ImplCommand_2>
    {
        public ImplMicroserviceProcessManager_2(
            AmqpSessionFactory factory,
            ICommandHandlerAsync<ImplCommand_2> commandHandler_2)
            : base(factory, commandHandler_2)
        {}

        protected override ImplCommand_2 Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<ImplCommand_2>(data);
        }

        public ImplCommand_2 TestDeserializer2(string data)
        {
            return Deserialize(data);
        }
    }
}
