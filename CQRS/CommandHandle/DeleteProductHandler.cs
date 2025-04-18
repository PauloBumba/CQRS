using CQRS.Command;
using CQRS.Models;
using CQRS.Repository;

namespace CQRS.CommandHandle
{
    public class DeleteProductHandler
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle (DeleteProductCommand command)
        {
            var product = new Product()
            {
                Id = command.ID,
            };

            await _repository.DeleteAsync(product.Id);
            return product;
        }
    }
}
