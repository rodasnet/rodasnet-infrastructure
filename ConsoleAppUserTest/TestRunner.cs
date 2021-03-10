using Microsoft.Extensions.Hosting;
using Rodasnet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppUserTest
{
    public class TestRunner : BackgroundService
    {
        private readonly Test_ImplMicroserviceProcessManager manager;

        private readonly IProcessorAsync processor;
        private readonly Test_Rodasnet_EventBus evenBusTest;

        public TestRunner(Test_ImplMicroserviceProcessManager manager, IProcessorAsync processor, Test_Rodasnet_EventBus eventBus)
        {
            this.manager = manager;
            this.processor  = processor;
            this.evenBusTest = eventBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Sending Message with EventBusAsync");

            evenBusTest.RunAsync().GetAwaiter().GetResult();
            /*
            Parallel.For(1, 5, (i) => {
                if (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("... await manager.RunAsync()");
                    manager.RunAsync().GetAwaiter().GetResult();
                }
                else
                {
                    Console.WriteLine("STOPING Test_ImplMicroserviceProcessManager Worker running at: {time} with cancellation token: ", 
                        DateTimeOffset.Now, stoppingToken.ToString());
                }    
            });

            await Task.Delay(1000);

            Parallel.For(1, 5, (i) => {
                if (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("... await processor.StartAsync()");
                    processor.StartAsync().GetAwaiter().GetResult();
                }
                else
                {
                    Console.WriteLine("STOPING IProcessorAsync Worker running at: {time} with cancellation token: ",
                        DateTimeOffset.Now, stoppingToken.ToString());
                }
            });
            */
        }
    }
}
