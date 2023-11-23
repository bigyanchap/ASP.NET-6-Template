using cartApp.Entities;
using cartApp.Services;
using cartApp.Services.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cartapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("getProducts")]
        public IActionResult GetProducts()
        {
            var result = this._productService.GetAllProducts();
            return Ok(result);
        }
        [HttpGet]
        [Route("getProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                return Ok(this._productService.GetProuctById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("deleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var result = this._productService.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("addProduct")]
        public IActionResult CreateProduct(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
        [HttpPut]
        [Route("updateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                var result = _productService.UpdateProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
