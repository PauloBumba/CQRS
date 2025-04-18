using AutoMapper;
using CQRS.Command;
using CQRS.Models;
using CQRS.Repository;

namespace CQRS.CommandHandle
{
   
    public class CreateProductHandler
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public CreateProductHandler( IProductRepository repository , IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> Handle (CreateProductCommand command)
        {
            var product = _mapper.Map<Product>( command );


            await _repository.CreateAsync (product);
            return product;
        }
    }
}
