using CQRS.Models;
using CQRS.Query;
using CQRS.Repository;

namespace CQRS.QueryHandle
{
    public class GetProductByIdHandler
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product?> Handle(GetProdutoByIdQuery query )
        {
           return  await _repository.GetByIdAsync(query.Id);

        }
    }
}
