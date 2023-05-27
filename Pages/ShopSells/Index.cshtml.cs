using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;
using System.Linq;

namespace TrasladoSeguro.Pages.ShopSells
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<ShopSell> ShopSells { get; set; } = default!;


        public async Task OnGetAsync()
        {

            if (_context.ShopSells != null)
            {
                ShopSells = await _context.ShopSells.ToListAsync();
            }
        }
    }
}
