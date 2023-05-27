using Microsoft.AspNetCore.Razor.TagHelpers;
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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PayMode> PayModes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ShopSell> ShopSells { get; set; }
    }
}
