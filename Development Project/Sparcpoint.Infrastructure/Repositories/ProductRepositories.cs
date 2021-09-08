using Sparcpoint.Domain.Aggregates.ProductAggregate;
using Sparcpoint.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparcpoint.Domain.ValueObjects;

namespace Sparcpoint.Infrastructure.Repositories
{
    public class ProductRepositories : IProductRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Task<Product> AddAsync(Product productToAdd)
        {
            var fakeProduct = new Product("ProductName1", new Domain.ValueObjects.Money(10.99m, Currency.USD), new List<Category>());
            return Task.FromResult(fakeProduct);
        }

        public Task<Product> GetAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product productToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
