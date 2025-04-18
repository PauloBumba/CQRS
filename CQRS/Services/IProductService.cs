using CQRS.Command;
using CQRS.Models;
using CQRS.Query;

namespace CQRS.Services
{
    public interface IProductService
    {
        Task<Envelop<List<Product>>> GetProductAl();
        Task<Envelop<Product>> GetProductAl(GetProdutoByIdQuery query);
        Task<Envelop<Product>> CreateProduct( CreateProductCommand command);
        Task<Envelop<Product>> UpdateProduct( UpdateProoductCommand command);
        Task<Envelop<Product>> DeleteProduct(DeleteProductCommand command);
    }
}
