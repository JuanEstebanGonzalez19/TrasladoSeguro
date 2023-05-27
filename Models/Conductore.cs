namespace TrasladoSeguro.Models
{
    public class Conductore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Telefono { get; set; }
        public int PrecioEstandar { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;
    }
}
