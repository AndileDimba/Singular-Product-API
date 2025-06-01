using Singular_Product_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Singular_Product_API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductSalesDTO>> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    }
}
