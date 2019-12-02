namespace Application.Products
{
    public class ProductDto
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }
        public double Price { get; set; }
      
        public string Grade { get; set; }
        public string Diameter { get; set; }
        public string Length { get; set; }
    }
}