using Newtonsoft.Json;
using Rodasnet.Infrastructure.Messaging;
using Rodasnet.Infrastructure.Messaging.Handling;
using Rodasnet.Infrastructure.Processes;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppUserTest
{
    public class ImplProcessorAsync : AbstractProcessorAsync<ImplEvent>
    {
        public ImplProcessorAsync(ImplProcessorAsyncSessionFactory factory, 
            IEventHandlerAsync<ImplEvent> handler) : base(factory,handler)
        {
        }

        protected override ImplEvent Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<ImplEvent>(data);
        }
    }
}
