using CQRS.Command;
using CQRS.Models;
using CQRS.Repository;

namespace CQRS.CommandHandle
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _repository;
        public CreateProductHandler( IProductRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<Product> Handle (CreateProductCommand command)
        {
            var product = new Product
            {
                Price = command.Price,
                Name = command.Name,
            };

            await _repository.CreateAsync (product);
            return product;
        }
    }
}
