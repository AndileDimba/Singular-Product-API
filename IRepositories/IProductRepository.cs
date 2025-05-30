using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singular_Product_API.DTOs;

namespace Singular_Product_API.IRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductSalesDTO>> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    }
}
