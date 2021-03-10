using Rodasnet.Infrastructure.Messaging;
using Newtonsoft.Json;
using Rodasnet.Infrastructure.Messaging.Handling;
using Rodasnet.Infrastructure.Processes;

namespace ConsoleAppUserTest
{
    class ImplMicroserviceProcessManager : MicroserviceProcessManager<ImplCommand>
    {
        public ImplMicroserviceProcessManager(
            AmqpSessionFactory factory, 
            ICommandHandlerAsync<ImplCommand> commandHandler)
            : base(factory, commandHandler)
        {}

        protected override ImplCommand Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<ImplCommand>(data);
        }
    }
}
