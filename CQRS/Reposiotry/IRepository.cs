using CQRS.Models;

namespace CQRS.Repository
{
    public interface IRepository
    {
        Task<List<Product>> GetAllAsync();  

        Task<Product> GetByIdAsync(int id); 

        Task<Product> CreateAsync(Product product); 

        Task<Product> UpdateAsync(Product product);  

        Task DeleteAsync(int id);  
    }
}
