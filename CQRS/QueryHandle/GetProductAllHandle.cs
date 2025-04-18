using CQRS.Models;
using CQRS.Repository;

namespace CQRS.QueryHandle
{

    public class GetProductAllHandler
    {
        private readonly IProductRepository _repository;

        public GetProductAllHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle()
        {
          return  await _repository.GetAllAsync(); 
        }
    }
}
