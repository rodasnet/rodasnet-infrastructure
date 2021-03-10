using Rodasnet.Infrastructure.Messaging.Handling;
using System;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class ImplCommandHandler : ICommandHandlerAsync<ImplCommand> //, ICommandHandlerAsync<ImplCommand_2>
    {
        public ImplCommand Command { get; set; }
        //public ImplCommand_2 Command2 { get; set; }

        public async Task HandleAsync(ImplCommand command)
        {
            Console.WriteLine($"Handling ImplCommand Id: {command.Id}.");
            Console.WriteLine($"Handling ImplCommand GuidProp: {command.GuidProp}.");
            Console.WriteLine($"Handling ImplCommand StringProp: {command.StringProp}.");
            Console.WriteLine($"Handling ImplCommand IntListProp count: {command.IntListProp.Count}.");
            Console.WriteLine($"Handling ImplCommand IntProp: {command.IntProp}.");
            Console.WriteLine($"Handling ImplCommand ObjProp: {command.ObjProp}.");
            Console.WriteLine($"Handling ImplCommand FloatProp: {command.FloatProp}.");

            Command = command;

            await Task.Delay(1000);
        }

        //public async Task HandleAsync(ImplCommand_2 command)
        //{
        //    Console.WriteLine($"Handling ImplCommand Id: {command.Id}.");
        //    Console.WriteLine($"Handling ImplCommand GuidProp: {command.GuidProp}.");
        //    Console.WriteLine($"Handling ImplCommand StringProp: {command.StringProp}.");
        //    Console.WriteLine($"Handling ImplCommand IntListProp count: {command.IntListProp.Count}.");
        //    Console.WriteLine($"Handling ImplCommand IntProp: {command.IntProp}.");
        //    Console.WriteLine($"Handling ImplCommand ObjProp: {command.ObjProp}.");
        //    Console.WriteLine($"Handling ImplCommand FloatProp: {command.FloatProp}.");

        //    Command2 = command;

        //    await Task.Delay(1000);
        //}

        public ImplCommand HandleAsyncTest(ImplCommand command)
        {
            HandleAsync(command).GetAwaiter().GetResult();
            return Command;
        }

        //public ImplCommand_2 HandleAsyncTest2(ImplCommand_2 command)
        //{
        //    HandleAsync(command).GetAwaiter().GetResult();
        //    return Command2;
        //}
    }
}