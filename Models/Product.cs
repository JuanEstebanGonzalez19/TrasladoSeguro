using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrasladoSeguro.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
