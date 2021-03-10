using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleAppUserTest
{
    public class Test_ImplMicroserviceProcessManager
    {
        private readonly ImplSessionFactory factory;

        public Test_ImplMicroserviceProcessManager(ImplSessionFactory factory)
        {
            this.factory = factory;
        }

        public async Task RunAsync()
        {
            var sender = new MessageSenderAsync();

            var thing = new { 
                Id    = Guid.NewGuid(),
                Prop2 = Guid.NewGuid(),
                Prop3 = Guid.NewGuid(),
                Prop4 = Guid.NewGuid(),
                Prop5 = Guid.NewGuid()
            };

            Console.WriteLine($"Thing is: {thing}");

            var json = JsonConvert.SerializeObject(thing);

            var message = new Amqp.Message(json);

            await sender.SendAsync(message);

            var handler = new ImplCommandHandler();

            var manager = new ImplMicroserviceProcessManager(factory, handler);

            await manager.ReceiveCommandAsync();
        }
    }
}
