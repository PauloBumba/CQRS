using AutoMapper;
using CQRS.Models;
using CQRS.Query;
using CQRS.Repository;
using MediatR;

namespace CQRS.QueryHandle
{
    public class GetProductByIdHandler : IRequestHandler<GetProdutoByIdQuery , Product>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        public async Task<Product> Handle(GetProdutoByIdQuery query , CancellationToken cancellationToken)
        {
           
            var product=  await _repository.GetByIdAsync(query.Id);

            if (product == null) {return null;}


            return product;

        }
    }
}
