using Rodasnet.Infrastructure.HealthCheck;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class RepositoryAddTest : IClassFixture<InMemoryTestFixture>
    {
        private readonly InMemoryTestFixture _fixture;

        public RepositoryAddTest(InMemoryTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public  void ShouldAddNewEntry()
        {
            var repo = new HealthCheckRepository(_fixture.HealthContext);

            var health = new HealthCheckEntry()
            {
                ApiVersion = "Version 1",
                Echo = "ECHO right back at you."
            };

            repo.AddAsync(health).GetAwaiter().GetResult();

            var result = repo.SaveChangesAsync().GetAwaiter().GetResult();

            int actual = 0;

            if (result > 0)
                actual = 1;

            Assert.Equal(1, actual);

            Assert.Equal(1, health.Id);

        }
    }
}
