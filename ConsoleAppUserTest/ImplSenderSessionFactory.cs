using Microsoft.Extensions.Configuration;
using Rodasnet.Infrastructure.Messaging;

namespace ConsoleAppUserTest
{
    public class ImplSenderSessionFactory : AmqpSessionFactory
    {
        private readonly IConfiguration _configuration;

        public ImplSenderSessionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override SessionConfiguration ConfigureSession()
        {
            return _configuration
                .GetSection("ImplSenderSessionFactory:SessionConfiguration")
                .Get<SessionConfiguration>();
        }
    }
}
