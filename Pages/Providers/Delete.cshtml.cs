using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Providers
{
    public class DeleteModel : PageModel
    {
        private readonly TrasladoContext _context;
        public DeleteModel(TrasladoContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }

            var providers = await _context.Providers.FirstOrDefaultAsync(m => m.Id == id);

            if (providers == null)
            {
                return NotFound();
            }
            else
            {
                Provider = providers;
            }
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Providers == null)
            {
                return NotFound();
            }
            var provider = await _context.Providers.FindAsync(id);

            if (provider != null)
            {
                Provider = provider;
                _context.Providers.Remove(Provider);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
