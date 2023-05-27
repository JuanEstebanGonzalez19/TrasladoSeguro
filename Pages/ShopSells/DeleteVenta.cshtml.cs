using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.ShopSells
{
    public class DeleteVentaModel : PageModel
    {
        private readonly TrasladoContext _context;
        public DeleteVentaModel(TrasladoContext context)
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
            else
            {
                ShopSell = shopSell;
            }
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ShopSells == null)
            {
                return NotFound();
            }
            var shopSell = await _context.ShopSells.FindAsync(id);

            if (shopSell != null)
            {
                ShopSell = shopSell;
                _context.ShopSells.Remove(ShopSell);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
