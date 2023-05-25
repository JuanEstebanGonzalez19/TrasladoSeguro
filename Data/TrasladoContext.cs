using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Data
{
    public class TrasladoContext : DbContext
    {
        public TrasladoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }


        public DbSet<Cliente> Clientes { get; set; }
    }
}
