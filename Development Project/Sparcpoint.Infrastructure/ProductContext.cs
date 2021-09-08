using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sparcpoint.Domain.Aggregates.ProductAggregate;
using Sparcpoint.Domain.SeedWork;

namespace Sparcpoint.Infrastructure
{
    public class ProductContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
