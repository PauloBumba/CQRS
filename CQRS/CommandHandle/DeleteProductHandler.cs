using AutoMapper;
using CQRS.Command;
using CQRS.Models;
using CQRS.Repository;
using MediatR;

namespace CQRS.CommandHandle
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand , Product>
    {
       
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
      

        public DeleteProductHandler(IProductRepository repository ,  IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
           
        }

        public async Task<Product> Handle (DeleteProductCommand command , CancellationToken cancellationToken)
        {
             var delete = _mapper.Map<Product>(command);

            if (delete == null) return null;

            await _repository.DeleteAsync(delete.Id);

           
            return delete;
        }
    }
}
