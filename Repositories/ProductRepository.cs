using Microsoft.Extensions.Configuration;
using Singular_Product_API.Exceptions;
using Singular_Product_API.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Singular_Product_API.DTOs;

namespace Singular_Product_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly JsonSerializerOptions _options;
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient = new HttpClient();
        public ProductRepository(IConfiguration configuration)
        {
            this._baseUrl = configuration["SingularSystemsApi:baseurl"] 
                ?? throw new ArgumentNullException("SingularSystemsApi:baseurl", "Url is not configured.");
            _httpClient.BaseAddress = new Uri(this._baseUrl);

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("/products/");

            if (!response.IsSuccessStatusCode)
            {
                if ((int)response.StatusCode == 404)
                {
                    throw new NotFoundException(nameof(GetAllProductsAsync), '-');
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<ProductDTO>>(content, _options);

            return products ?? new List<ProductDTO>();
        }

        public async Task<IEnumerable<ProductSalesDTO>> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/product-sales?Id={id}");
            
            if (!response.IsSuccessStatusCode)
            {
                if ((int)response.StatusCode == 404)
                {
                    throw new NotFoundException(nameof(GetProductByIdAsync), id);
                }
                else
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            
            
                var content = await response.Content.ReadAsStringAsync();
                var productSales = JsonSerializer.Deserialize<List<ProductSalesDTO>>(content, _options);

            return productSales ?? new List<ProductSalesDTO>();
        }
    }
}
