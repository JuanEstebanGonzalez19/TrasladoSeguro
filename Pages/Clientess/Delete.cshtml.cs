using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Clientess
{
    public class DeleteModel : PageModel
    {
        private readonly TrasladoContext _context;
        public DeleteModel(TrasladoContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientess == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientess.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                Cliente = cliente;
            }
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clientess == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientess.FindAsync(id);

            if (cliente != null)
            {
                Cliente = cliente;
                _context.Clientess.Remove(Cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
