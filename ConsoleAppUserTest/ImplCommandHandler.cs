using System;
using System.Threading.Tasks;
using Rodasnet.Infrastructure.Messaging.Handling;

namespace ConsoleAppUserTest
{
    public class ImplCommandHandler : ICommandHandlerAsync<ImplCommand>
    {
        public async Task HandleAsync(ImplCommand command)
        {
            Console.WriteLine($"Handling ImplCommand Id: {command.Id}.");
            Console.WriteLine($"Handling ImplCommand Prop2: {command.Prop2}.");
            Console.WriteLine($"Handling ImplCommand Prop3: {command.Prop3}.");
            Console.WriteLine($"Handling ImplCommand Prop4: {command.Prop4}.");
            Console.WriteLine($"Handling ImplCommand Prop5: {command.Prop5}.");

            await Task.Delay(1000);
            Console.WriteLine("That was a good 1 second nap.");
        }
    }
}
