using CQRS.Command;
using CQRS.Data;
using CQRS.Models;
using CQRS.Query;
using CQRS.Repository;

namespace CQRS.Reposiotry
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _Context;

        public ProductRepository(ProductDbContext context)
      
        {
            _Context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
             await _Context.produtct.AddAsync(product);
              await _Context.SaveChangesAsync();
            return product;

        }

        public Task DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
