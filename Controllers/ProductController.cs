using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Singular_Product_API.DTOs;
using Singular_Product_API.Exceptions;
using Singular_Product_API.IRepositories;



namespace Singular_Product_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;

        }

        [HttpGet]
        [Route("all-products")]
        public async Task<ActionResult<ProductDTO>> GetAllProducts()
        {
            _logger.LogInformation($"Getting All Products attempt in {nameof(GetAllProducts)}");
            var products = await _productRepository.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<ActionResult<ProductSalesDTO>> GetProductById(int id)
        {
            _logger.LogInformation($"Getting Product by Id attempt in {nameof(GetProductById)}");

            if (id < 0)
            {
                _logger.LogError($"Invalid GetProductById attempt In {nameof(GetProductById)}");
                throw new BadRequestException(nameof(GetProductById), id);
            }

            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
