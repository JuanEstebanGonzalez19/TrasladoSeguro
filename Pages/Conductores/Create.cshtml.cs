using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Conductores
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
        public Conductore Conductore { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Conductores == null || Conductore == null)
            {
                return Page();
            }

            _context.Conductores.Add(Conductore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

