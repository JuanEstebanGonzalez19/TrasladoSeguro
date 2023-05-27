using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.PayModes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<PayMode> PayModes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PayModes != null)
            {
                PayModes = await _context.PayModes.ToListAsync();
            }
        }
    }
}
