using Rodasnet.Infrastructure.Messaging;
using Rodasnet.Infrastructure.Processes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplProcessManager : IProcessManager
    {
        public ImplProcessManager()
        {
            Id = new Guid("94b94182-abef-4d77-af36-e27d36643659");
        }

        public Guid Id { get; }

        public bool Completed => throw new NotImplementedException();

        public IEnumerable<Envelope<ICommand>> Commands => throw new NotImplementedException();

        public async Task HandleAsync(ImplEvent @event)
        {
            Console.WriteLine($"Handling ImplEvent @event {@event}");

            await Task.Delay(500);
        }

        public async Task HandleAsync(ImplEvent_2 @event)
        {
            Console.WriteLine($"Handling ImplEvent_2 @event {@event}");

            await Task.Delay(500);
        }
    }
}
