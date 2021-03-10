namespace Rodasnet.Infrastructure.Messaging
{
    using System.Net;

    public abstract class AmqpSessionFactory
    {
        public string LinkName { get; internal set; }

        public string Topic { get; internal set; }

        // https://carlos.mendible.com/2016/07/17/step-by-step-net-core-azure-service-bus-and-amqp/
        public Amqp.Session CreateSession()
        {
            try
            {
                var c = ConfigureSession();

                LinkName = c.Link;
                Topic = c.Topic;

                return new Amqp.Session(
                    new Connection(
                        new Amqp.Address(
                            // Create the AMQP connection string
                            $"amqps://{WebUtility.UrlEncode(c.Policy)}:{WebUtility.UrlEncode(c.Key)}@{c.NamespaceUrl}/"
                        )
                    )
                );
            }
            catch (System.Exception)
            {
                throw new System.Exception("Could not create AMQP session.");
            }
        }

        /*********************************************************************************************************
        **********************************************************************************************************
        ** Example usage:                                                                                       **
        **********************************************************************************************************
        **********************************************************************************************************
        *                                                                                                        *
        *  // OPTION 1: Manual instantiate new instance SessionConfiguation                                      *
        *  public override SessionConfiguration ConfigureSession()                                               *
        *  {                                                                                                     *
        *      // OPTION 1: Manual instantiate new instance SessionConfiguation                                  *
        *      return new SessionConfiguration                                                                   *
        *      {                                                                                                 *
        *          Policy          = _configuration["ServiceBus:make-new-balance-queue:ReceivePolicy:name"],     *
        *          Key             = _configuration["ServiceBus:make-new-balance-queue:ReceivePolicy:Key"],      *
        *          NamespaceUrl    = _configuration["ServiceBus:make-new-balance-queue:NamespaceUrl"],           *
        *          Topic           = "make-new-balance-debit-dev",                                               *
        *          Link            = "sb-listener-balance-microservice"                                          *
        *      };                                                                                                *
        *   }                                                                                                    *
        *                                                                                                        *
        *  // OPTION 2: Use dependancy injection to return instance of SessionConfiguration                      *
        *  public override SessionConfiguration ConfigureSession()                                               *
        *  {                                                                                                     *
        *      return _configuration.GetSection("SessionConfiguration").Get<SessionConfiguration>();             *
        *  }                                                                                                     *
        *                                                                                                        *
        **********************************************************************************************************/
        public abstract SessionConfiguration ConfigureSession();
    }
}
