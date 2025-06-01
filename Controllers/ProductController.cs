using Microsoft.AspNetCore.Mvc;
using Singular_Product_API.DTOs;
using Singular_Product_API.Services;

namespace Singular_Product_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        [Route("all-products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation($"GetAllProducts endpoint called - Page: {page}, PageSize: {pageSize}");

            var products = await _productService.GetAllProductsAsync(page, pageSize);
            return Ok(products);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<ActionResult<IEnumerable<ProductSalesDTO>>> GetProductById(int id)
        {
            _logger.LogInformation($"GetProductById endpoint called for ID: {id}");

            var productSales = await _productService.GetProductByIdAsync(id);

            if (productSales == null || !productSales.Any())
            {
                _logger.LogWarning($"No sales data found for product ID: {id}");
                return NotFound($"No sales data found for product ID: {id}");
            }

            return Ok(productSales);
        }
    }
}