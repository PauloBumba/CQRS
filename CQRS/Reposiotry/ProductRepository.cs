using CQRS.Command;
using CQRS.Data;
using CQRS.Models;
using CQRS.Query;
using CQRS.Repository;
using Microsoft.EntityFrameworkCore;

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
             await _Context.product.AddAsync(product);
             await _Context.SaveChangesAsync();
             return product;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            var product = await _Context.product.FindAsync(id);
            if (product == null) return null;

            _Context.product.Remove(product);
            await _Context.SaveChangesAsync();

            return product;
        }


        public async Task<List<Product>> GetAllAsync()
        {
           return await _Context.product.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _Context.product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _Context.product.Update(product);
            await _Context.SaveChangesAsync();
            return product;
        }
    }
}
