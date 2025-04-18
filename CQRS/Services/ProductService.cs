using CQRS.Command;
using CQRS.CommandHandle;
using CQRS.Models;
using CQRS.Query;
using CQRS.QueryHandle;

namespace CQRS.Services
{
    public class Productservice : IProductService
    {
        private readonly CreateProductHandler _createProduct;
        private readonly GetProductAllHandler _handler;
        public Productservice( CreateProductHandler createProduct , GetProductAllHandler handler )
        {
            _createProduct = createProduct;
            _handler = handler;
          
        }
        public async Task<Envelop<Product>> CreateProduct(CreateProductCommand command)
        {
           var create=  await _createProduct.Handle(command);
           
            if (create == null) 
            {
                return new Envelop<Product>
                {
                    Data = null,
                    isSucess = false,
                    Message = "Erro ao cadastrar o usuario "
                };
            }

            return new Envelop<Product>
            {
               
                isSucess = true,
                Message = "Usuario Criado com sucesso",
                Data = create,
            };
            
        }

        public Task<Envelop<Product>> DeleteProduct(DeleteProductCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<Envelop<List<Product>>> GetProductAl()
        {
             var readAll = await _handler.Handle();
            if (readAll == null)
            {
                return new Envelop<List<Product>>
                {
                    Data = null,
                    isSucess = false,
                    Message = "Não tem dados no banco de dados"
                };
            }

            return new Envelop<List<Product>>
            {
                Message = "Lista de Todos os Produto cadastro do banco de dados",
                Data= readAll,
                isSucess=true,
            };


        }

        public Task<Envelop<Product>> GetProductAl(GetProdutoByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<Envelop<Product>> UpdateProduct(UpdateProoductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
