using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rodasnet.Infrastructure;

namespace ConsoleAppUserTest
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IProcessorAsync _processor;

        public Worker(ILogger<Worker> logger, IProcessorAsync processor)
        {
            _logger = logger;
            _processor = processor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ImplProcessManagerRouter Processor Worker started running at: {time}", DateTimeOffset.Now);
   
            while (true)
            {
                if(!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("_processor.StartAsync()");
                    await _processor.StartAsync();
                } else
                {
                    _logger.LogInformation("STOPING ImplProcessManagerRouter Processor Worker running at: {time} with cancellation token: ", DateTimeOffset.Now, stoppingToken.ToString());   
                }     
            }
        }
    }
}
