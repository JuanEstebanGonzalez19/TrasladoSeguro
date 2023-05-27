using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Productos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<Producto> Productos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Productos != null)
            {
                Productos = await _context.Productos.ToListAsync();
            }
        }
    }
}
