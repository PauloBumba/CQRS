using CQRS.Command;
using CQRS.CommandHandle;
using CQRS.Models;
using CQRS.Query;
using CQRS.QueryHandle;
using MediatR;

namespace CQRS.Services
{
    public class Productservice : IProductService
    {
        private readonly IMediator _mediator;
        private readonly CreateProductHandler _createProduct;
        private readonly GetProductAllHandler _handler;
        private readonly GetProductByIdHandler _getProductById;
        private readonly UpdaterProductHandler _updaterProduct;
        private readonly DeleteProductHandler _deleteProduct;
        public Productservice( CreateProductHandler createProduct , GetProductAllHandler handler , GetProductByIdHandler  getProductById , UpdaterProductHandler updaterProduct , DeleteProductHandler deleteProduct,  IMediator mediator)
        {
            _createProduct = createProduct;
            _handler = handler;
            _getProductById = getProductById;
            _updaterProduct = updaterProduct;
            _deleteProduct = deleteProduct;
            _mediator = mediator;
        }
        public async Task<Envelop<Product>> CreateProduct(CreateProductCommand command )
        {
            var create = await _mediator.Send(command);

            if (create == null) 
            {
                return new Envelop<Product>
                {
                    Data = null,
                    isSucess = false,
                    Message = "Erro ao criar Produto "
                };
            }

            return new Envelop<Product>
            {
               
                isSucess = true,
                Message = "Produto criado com sucesso",
                Data = create,
            };
            
        }

        public async Task<Envelop<Product>> DeleteProduct(DeleteProductCommand command)
        {
             var delete = await _mediator.Send(command);

              if(delete == null)
              {
                return new Envelop<Product>
                {
                    Data = null,
                    isSucess = false,
                    Message = "Erro ao deletar o produto"
                };

              }

            return new Envelop<Product>
            {
                isSucess = true,
                Message = "Produto Deletado",
                Data = delete,
            };
        }

        public async Task<Envelop<List<Product>>> GetProductAl( GetProductAllQuery query)
        {
            var products = await _mediator.Send(query);

            if (products == null || !products.Any())
            {
                return new Envelop<List<Product>>
                {
                    Data = null,
                    isSucess = false,
                    Message = "Não há produtos cadastrados no banco de dados."
                };
            }

            return new Envelop<List<Product>>
            {
                Data = products,
                isSucess = true,
                Message = "Lista de produtos carregada com sucesso."
            };

        }

        public async Task<Envelop<Product>> GetProductById(GetProdutoByIdQuery query)
        {
            var get = await _mediator.Send(query);
            if (get == null)
            {
                return new Envelop<Product> { Data = null, isSucess = false, Message = "Id não cadastrado" };
            }
            return new Envelop<Product>
            {
                Data = get,
                isSucess = true,
                Message = "Busca do Usuario"
            };
        }

        public async Task<Envelop<Product>> UpdateProduct(UpdateProoductCommand command)
        {
            var update = await _mediator.Send(command);
            if (update == null)
            {
                return new Envelop<Product>
                {
                    Data = null,
                    isSucess = false,
                    Message = "Erro ao atualizar o produto"
                };
            }

            return new Envelop<Product>
            {
                Data= update,
                isSucess = true,
                Message=  "Produto Atualizado "
            };
        }
    }
}
