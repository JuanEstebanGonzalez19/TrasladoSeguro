namespace TrasladoSeguro.Models
{
    public class ShopSell
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int Sale_Percentage { get; set; }
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;
    }
}
