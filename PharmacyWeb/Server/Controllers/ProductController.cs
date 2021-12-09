using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyWeb.Server.Data;
using PharmacyWeb.Server.Services.ProductService;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProducts();
            return Ok(result);
        }
        [HttpGet("category/{categoryIndex}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(int categoryIndex)
        {
            var result = await _productService.GetProductsByCategory(categoryIndex);
            return Ok(result);
        }
    }
}
