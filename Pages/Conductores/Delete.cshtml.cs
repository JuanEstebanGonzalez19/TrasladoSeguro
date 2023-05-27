using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Conductores
{
    public class DeleteModel : PageModel
    {
        private readonly TrasladoContext _context;
        public DeleteModel(TrasladoContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Conductore Conductore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Conductores == null)
            {
                return NotFound();
            }

            var conductore = await _context.Conductores.FirstOrDefaultAsync(m => m.Id == id);

            if (conductore == null)
            {
                return NotFound();
            }
            else
            {
                Conductore = conductore;
            }
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Conductores == null)
            {
                return NotFound();
            }
            var conductore = await _context.Conductores.FindAsync(id);

            if (conductore != null)
            {
                Conductore = conductore;
                _context.Conductores.Remove(Conductore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
