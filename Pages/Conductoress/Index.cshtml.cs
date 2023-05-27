using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Conductoress
{
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<Conductore> Conductoress { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Conductoress != null)
            {
                Conductoress = await _context.Conductoress.ToListAsync();
            }
        }

    }
}
