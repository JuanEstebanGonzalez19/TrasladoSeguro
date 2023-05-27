using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Conductores
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<Conductore> Conductores { get; set; } = default!;
        
        public async Task OnGetAsync() 
        {
            if (_context.Conductores != null) 
            {
                Conductores = await _context.Conductores.ToListAsync();
            }
        }
    }
}
