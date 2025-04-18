using CQRS.Command;
using CQRS.Query;
using CQRS.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        private readonly IValidator<CreateProductCommand> _validatorCreateProduct;
        private readonly IValidator<UpdateProoductCommand> _validatorUpdateProduct;
        public ProductController(IProductService productservice , IValidator <CreateProductCommand > validateCreateProduct , IValidator <UpdateProoductCommand>  validateUpdateProduct)
        {
            _productservice = productservice;
            _validatorCreateProduct = validateCreateProduct;
            _validatorUpdateProduct = validateUpdateProduct;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            try
            {
                var validate= await _validatorCreateProduct.ValidateAsync(command);
                if (!validate.IsValid)
                {
                    return BadRequest(validate.Errors);
                }
                var product = await _productservice.CreateProduct(command);
                return Ok(new { product });
            }
            catch (Exception ex)
            {
               return  BadRequest(ex);
               
            }

        }
        [HttpGet("readId")]
        public async Task<IActionResult> ReadProductId([FromQuery] GetProdutoByIdQuery query)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ReadId = await _productservice.GetProductById(query);
                return Ok(new { ReadId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("read")]
        public async Task<IActionResult> ReadProduct()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Read = await _productservice.GetProductAl();
                return Ok(new {Read});
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct(UpdateProoductCommand command)
        {
            try
            {
                var validate = await _validatorUpdateProduct.ValidateAsync(command);
                if (!validate.IsValid)
                {
                    return BadRequest(validate.Errors);
                }
                var update =await _productservice.UpdateProduct(command);
                return Ok(new {update});
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProduto( DeleteProductCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var delete =  await _productservice.DeleteProduct(command);
                return Ok(new {delete});
            }

            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
