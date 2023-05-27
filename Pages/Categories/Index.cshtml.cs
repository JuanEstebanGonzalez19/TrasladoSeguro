using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Categories
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = default!;
        
        public async Task OnGetAsync() 
        {
            if (_context.Categories != null) 
            {
                Categories= await _context.Categories.ToListAsync();
            }
        }
    }
}
