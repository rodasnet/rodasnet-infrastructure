using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rodasnet.Infrastructure.Domain
{
    public abstract class SaveAsyncContext 
    {
        protected readonly DbContext _dbContext;

        public SaveAsyncContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
