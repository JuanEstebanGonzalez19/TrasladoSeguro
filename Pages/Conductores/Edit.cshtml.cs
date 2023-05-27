using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Conductores
{
    public class EditModel : PageModel
    {
        private readonly TrasladoContext _context;

        public EditModel(TrasladoContext context)
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
            Conductore = conductore;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Conductore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConductoreExists(Conductore.Id))
                {
                    return Page();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConductoreExists(int id)
        {
            return (_context.Conductores?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
