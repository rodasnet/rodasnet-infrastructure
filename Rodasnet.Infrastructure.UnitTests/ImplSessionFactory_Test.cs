using Rodasnet.Infrastructure.Messaging;
using System;
using System.Net;
using Xunit;

namespace Rodasnet.Infrastructure.UnitTests
{
    public class ImplSessionFactory_Test
    {
        [Fact]
        public void Create_SesseionFactory_Success()
        {
            var sut = new ImplSessionFactory();
            Assert.IsType<ImplSessionFactory>(sut);
        }

        [Fact]
        public void Configure_Sesseion_Success()
        {
            var sut = new ImplSessionFactory();

            var actual = sut.ConfigureSession();

            var expected = new SessionConfiguration
            {
                Policy = "Policy_Name",
                Key = "00000000000000000000000",
                NamespaceUrl = "target.servicebus.rodasnet.net",
                Topic = "Event_Or_Command",
                Link = "Amqp_Link_Name"
            };

            Assert.IsType<SessionConfiguration>(actual);

            Assert.Equal(expected.Policy,       actual.Policy);
            Assert.Equal(expected.Key,          actual.Key);
            Assert.Equal(expected.NamespaceUrl, actual.NamespaceUrl);
            Assert.Equal(expected.Topic,        actual.Topic);
            Assert.Equal(expected.Link,         actual.Link);
        }

        [Fact]
        public void Create_Sesseion_Throws_Exception()
        {
            /******************************************************/
            /* Explanation:                                       */
            /* Since this SessionConfiguration uses fake data     */
            /* Amqp.Session creation should fail with an exeption */
            /******************************************************/
            var sut = new ImplSessionFactory();
            Assert.Throws<Exception>(() => sut.CreateSession());
        }
    }
}
