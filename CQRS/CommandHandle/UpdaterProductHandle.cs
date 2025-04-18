using CQRS.Command;
using CQRS.Models;
using CQRS.Reposiotry;
using CQRS.Repository;

namespace CQRS.CommandHandle
{
    public class UpdaterProductHandler
    {
        private readonly IProductRepository _repository;

        public UpdaterProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task <Product> Handle(UpdateProoductCommand command)
        {
            var product = new Product
            {
                Id = command.Id,
                Name = command.Name,
                Price = command.Price,
            };

            await _repository.UpdateAsync(product);
            return product;
        }
    }
}
