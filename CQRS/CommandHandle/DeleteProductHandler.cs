using AutoMapper;
using CQRS.Command;
using CQRS.Models;
using CQRS.Repository;

namespace CQRS.CommandHandle
{
    public class DeleteProductHandler
    {
       
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository )
        {
            _repository = repository;
           
        }

        public async Task<Product> Handle (DeleteProductCommand command)
        {
           
             var delete=  await _repository.DeleteAsync(command.ID);
             if (delete == null) return null;
            
            return delete;
        }
    }
}
