using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Productos
{
    public class DeleteModel : PageModel
    {
        private readonly TrasladoContext _context;
        public DeleteModel(TrasladoContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                Producto = producto;
            }
            return Page();
        }




        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);

            if (producto != null)
            {
                Producto = producto;
                _context.Productos.Remove(Producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
