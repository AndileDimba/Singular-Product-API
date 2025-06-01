using Singular_Product_API.DTOs;
using Singular_Product_API.Exceptions;
using Singular_Product_API.Repositories;

namespace Singular_Product_API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(int page = 1, int pageSize = 10)
        {
            _logger.LogInformation($"Getting all products - Page: {page}, PageSize: {pageSize}");

            // Business logic: validate pagination parameters
            if (page < 1) page = 1;
            if (pageSize < 1 || pageSize > 100) pageSize = 10; // Max 100 items per page

            var allProducts = await _productRepository.GetAllProductsAsync();

            // Apply pagination
            var pagedProducts = allProducts
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return pagedProducts;
        }

        public async Task<IEnumerable<ProductSalesDTO>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Getting product sales for ID: {id}");

            // Business logic: validate input
            if (id <= 0)
            {
                _logger.LogError($"Invalid product ID: {id}");
                throw new BadRequestException(nameof(GetProductByIdAsync), id);
            }

            var productSales = await _productRepository.GetProductByIdAsync(id);

            return productSales;
        }
    }
}