using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Providers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<Provider> Providers { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Providers != null)
            {
                Providers = await _context.Providers.ToListAsync();
            }
        }
    }
}
