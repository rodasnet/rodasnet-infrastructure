using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Rodasnet.Infrastructure.HealthCheck;
using Rodasnet.Infrastructure.Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Rodasnet.Infrastructure;
using Rodasnet.Infrastructure.Messaging.Handling;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConsoleAppUserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ConsoleAppUserTest!");
            CreateHostBuilder(args).Build().Run();

            // TODO: TEST PROCESSOR CODE MORE THOROUGHLY !!
            // TODO: TEST -> Can this implementation handle multiple IEvent implementations in same program?
            // For example: ImplEvent, ImplEvent_2, ImplEvent_3, ... ?

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    builder.AddUserSecrets<Program>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<ImplSessionFactory, ImplSessionFactory>();
                    services.AddTransient<ImplSenderSessionFactory, ImplSenderSessionFactory>();
                    services.AddTransient<Test_Rodasnet_EventBus, Test_Rodasnet_EventBus>();
                    services.AddTransient<Test_ImplMicroserviceProcessManager, Test_ImplMicroserviceProcessManager>();
                    services.AddTransient<IEventHandlerAsync<ImplEvent>, ImplProcessManagerRouter>();
                    services.AddTransient<IEventHandlerAsync<ImplEvent_2>, ImplProcessManagerRouter>();

                    services.AddTransient<ImplProcessorAsyncSessionFactory, ImplProcessorAsyncSessionFactory>();
                    services.AddTransient<IProcessorAsync, ImplProcessorAsync>();
                    
                    services.AddHostedService<Worker>();
                    services.AddHostedService<TestRunner>();
                });
    }
}
