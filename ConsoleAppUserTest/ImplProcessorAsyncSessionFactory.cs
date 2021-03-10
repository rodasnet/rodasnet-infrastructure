using Microsoft.Extensions.Configuration;
using Rodasnet.Infrastructure.Messaging;

namespace ConsoleAppUserTest
{
    public class ImplProcessorAsyncSessionFactory : AmqpSessionFactory
    {
        private readonly IConfiguration _configuration;

        public ImplProcessorAsyncSessionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override SessionConfiguration ConfigureSession()
        {
            return _configuration
                .GetSection("ImplProcessorAsyncSessionFactory:SessionConfiguration")
                .Get<SessionConfiguration>();
        }
    }
}
