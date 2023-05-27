using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Conductoress
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
            if (!ModelState.IsValid || _context.Conductoress == null || Conductore == null)
            {
                return Page();
            }

            _context.Conductoress.Add(Conductore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
