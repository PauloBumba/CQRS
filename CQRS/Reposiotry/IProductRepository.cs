using CQRS.Command;
using CQRS.Models;
using CQRS.Query;

namespace CQRS.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync( Product product);  

        Task<Product> GetByIdAsync(Product product); 

        Task<Product> CreateAsync(Product product); 

        Task<Product> UpdateAsync(Product product);  

        Task DeleteAsync(Product product);  
    }
}
