namespace Singular_Product_API.DTOs
{
    public class ProductSalesDTO
    {
        public int saleId { get; set; }
        public int productId { get; set; }
        public double salePrice { get; set; }
        public int saleQty { get; set; }
        public string? saleDate { get; set; }
    }
}
