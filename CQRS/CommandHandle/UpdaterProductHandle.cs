using AutoMapper;
using CQRS.Command;
using CQRS.Models;
using CQRS.Reposiotry;
using CQRS.Repository;
using MediatR;

namespace CQRS.CommandHandle
{
    public class UpdaterProductHandler : IRequestHandler< UpdateProoductCommand,Product>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public UpdaterProductHandler(IProductRepository repository ,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task <Product> Handle(UpdateProoductCommand command , CancellationToken cancellationToken) 
        {
            var product = _mapper.Map<Product>(command);

            if (product == null) { return null; }
            await _repository.UpdateAsync(product);
            return product;
        }
    }
}
