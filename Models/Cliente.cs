namespace TrasladoSeguro.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;
    }
}
