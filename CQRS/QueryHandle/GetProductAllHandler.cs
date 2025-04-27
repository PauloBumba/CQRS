using CQRS.Models;
using CQRS.Query;
using CQRS.Repository;
using MediatR;

namespace CQRS.QueryHandle
{

    public class GetProductAllHandler : IRequestHandler<GetProductAllQuery , List<Product>>
    {
        private readonly IProductRepository _repository;

        public GetProductAllHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> Handle(GetProductAllQuery query , CancellationToken cancellationToken)
        {
          return  await _repository.GetAllAsync(); 
        }
    }
}
