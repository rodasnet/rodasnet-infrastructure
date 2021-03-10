using Rodasnet.Infrastructure.Messaging;
using Rodasnet.Infrastructure.Messaging.Handling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUserTest
{
    public class ImplProcessManagerRouter : IEventHandlerAsync<ImplEvent>, IEventHandlerAsync<ImplEvent_2>
    {
        public async Task HandleAsync(ImplEvent @event)
        {
            var process = new ImplProcessManager();

            await process.HandleAsync(@event);
        }

        public async Task HandleAsync(ImplEvent_2 @event)
        {
            var process = new ImplProcessManager();

            await process.HandleAsync(@event);
        }
    }
}
