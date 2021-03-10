using Microsoft.Extensions.Configuration;
using Rodasnet.Infrastructure.Messaging;

namespace ConsoleAppUserTest
{
    public class ImplSessionFactory : AmqpSessionFactory
    {
        private readonly IConfiguration _configuration;

        public ImplSessionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override SessionConfiguration ConfigureSession()
        {
            return _configuration
                .GetSection("ImplSessionFactory:SessionConfiguration")
                .Get<SessionConfiguration>();
        }
    }
}
