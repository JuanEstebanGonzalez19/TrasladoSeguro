using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Sells
{
    [Authorize]
    public class SellsModel : PageModel
    {
        private readonly TrasladoContext _context;
        public SellsModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<Producto> Productos { get; set; }

        public async Task OnGetAsync(string searchString)
        {



            var productos = from p in _context.Productos
                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(p => p.Name.Contains(searchString));
            }

            Productos = await productos.ToListAsync();

        }
    }
}
