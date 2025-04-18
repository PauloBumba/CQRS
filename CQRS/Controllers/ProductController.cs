using CQRS.Command;
using CQRS.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var product = await _productservice.CreateProduct(command);
                return Ok(new { product });
            }
            catch (Exception ex)
            {
               return  BadRequest(ex);
               
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
    }
}
