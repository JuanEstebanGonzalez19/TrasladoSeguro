using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.ShopSells
{
    public class CreateVentaModel : PageModel
    {
        private readonly TrasladoContext _context;

        public CreateVentaModel(TrasladoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public ShopSell ShopSell { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ShopSells == null || ShopSell == null)
            {
                return Page();
            }

            _context.ShopSells.Add(ShopSell);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
