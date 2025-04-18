using CQRS.Command;
using CQRS.Models;
using CQRS.Query;

namespace CQRS.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();  

        Task<Product?> GetByIdAsync(int id); 

        Task<Product> CreateAsync(Product product); 

        Task<Product> UpdateAsync(Product product);  

        Task <Product?> DeleteAsync(int id);  
    }
}
