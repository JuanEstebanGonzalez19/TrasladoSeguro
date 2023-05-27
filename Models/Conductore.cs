using System.Data.SqlTypes;

namespace TrasladoSeguro.Models
{
    public class Conductore
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int PrecioEstandar { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;
    }
}
