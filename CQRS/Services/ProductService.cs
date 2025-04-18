﻿using CQRS.Command;
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
        private readonly GetProductByIdHandler _getProductById;
        private readonly UpdaterProductHandler _updaterProduct;
        private readonly DeleteProductHandler _deleteProduct;
        public Productservice( CreateProductHandler createProduct , GetProductAllHandler handler , GetProductByIdHandler  getProductById , UpdaterProductHandler updaterProduct , DeleteProductHandler deleteProduct)
        {
            _createProduct = createProduct;
            _handler = handler;
            _getProductById = getProductById;
            _updaterProduct = updaterProduct;
            _deleteProduct = deleteProduct;
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

        public async Task<Envelop<Product>> DeleteProduct(DeleteProductCommand command)
        {
             var delete = await _deleteProduct.Handle(command);
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

        public async Task<Envelop<Product>> GetProductById(GetProdutoByIdQuery query)
        {
            var get = await _getProductById.Handle(query);
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
            var update = await _updaterProduct.Handle(command);
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
