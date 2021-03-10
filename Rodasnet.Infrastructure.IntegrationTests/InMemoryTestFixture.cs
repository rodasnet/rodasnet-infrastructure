using Microsoft.EntityFrameworkCore;
using Rodasnet.Infrastructure.HealthCheck;
using System;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class InMemoryTestFixture : IDisposable
    {
        public InMemoryTestFixture()
        {

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~InMemoryTestFixture()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        public TestDbContext Context => InMemoryContext();

        private TestDbContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new TestDbContext(options);

            return context;
        }

        public HealthCheckDbContext HealthContext => InMemoryHealthContext();

        private HealthCheckDbContext InMemoryHealthContext()
        {
            var options = new DbContextOptionsBuilder<HealthCheckDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var context = new HealthCheckDbContext(options);

            return context;
        }
    }
}