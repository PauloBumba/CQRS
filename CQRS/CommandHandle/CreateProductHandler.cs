using AutoMapper;
using CQRS.Command;
using CQRS.Models;
using CQRS.Repository;
using MediatR;

namespace CQRS.CommandHandle
{
   
    public class CreateProductHandler : IRequestHandler<CreateProductCommand,Product>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public CreateProductHandler( IProductRepository repository , IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> Handle (CreateProductCommand command , CancellationToken  cancellation)
        {
            var product = _mapper.Map<Product>( command );

            if (product == null) {return null; }

            await _repository.CreateAsync (product);
            return product;
        }
    }
}
