using Newtonsoft.Json;
using Rodasnet.Infrastructure.Messaging;
using Rodasnet.Infrastructure.Messaging.Handling;
using Rodasnet.Infrastructure.Processes;
using System.Collections.Generic;
using System.Text;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplProcessorAsync : AbstractProcessorAsync<ImplEvent>
    {
        public ImplProcessorAsync(ImplSessionFactory factory, 
            IEventHandlerAsync<ImplEvent> handler) : base(factory,handler)
        {
        }

        protected override ImplEvent Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<ImplEvent>(data);
        }
    }
}
