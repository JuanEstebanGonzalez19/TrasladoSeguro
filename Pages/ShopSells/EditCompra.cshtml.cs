using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.ShopSells
{
    public class EditCompraModel : PageModel
    {
        private readonly TrasladoContext _context;

        public EditCompraModel(TrasladoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShopSell ShopSell { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ShopSells == null)
            {
                return NotFound();
            }

            var shopSell = await _context.ShopSells.FirstOrDefaultAsync(m => m.Id == id);
            if (shopSell == null)
            {
                return NotFound();
            }
            ShopSell = shopSell;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShopSell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopSellExists(ShopSell.Id))
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

        private bool ShopSellExists(int id)
        {
            return (_context.ShopSells?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
