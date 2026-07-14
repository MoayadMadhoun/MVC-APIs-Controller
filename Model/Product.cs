namespace MVCAPIs_Controller.Model
{
    public class Product
    {
        public int Id { get; set; }
        public required string Sku { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
