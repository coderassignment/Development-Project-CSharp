using Sparcpoint.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparcpoint.Domain.Aggregates.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> AddAsync(Product productToAdd);

        Task UpdateAsync(Product productToUpdate);

        Task<Product> GetAsync(int productId);
    }
}
