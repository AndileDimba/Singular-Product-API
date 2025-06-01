using Singular_Product_API.DTOs;

namespace Singular_Product_API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync(int page = 1, int pageSize = 10);
        Task<IEnumerable<ProductSalesDTO>> GetProductByIdAsync(int id);
    }
}