namespace Singular_Product_API.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string? description { get; set; }
        public double salePrice { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
    }
}
