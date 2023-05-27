using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Clientess
{
    public class CreateModel : PageModel
    {
        private readonly TrasladoContext _context;

        public CreateModel(TrasladoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Cliente Cliente { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Conductores == null || Cliente == null)
            {
                return Page();
            }

            _context.Clientess.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
