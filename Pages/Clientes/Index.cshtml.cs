using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Clientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoContext _context;

        public IndexModel(TrasladoContext context)
        {
            _context = context;
        }

        public IList<Cliente> Clientes { get; set; } = default!;
        
        public async Task OnGetAsync() 
        {
            if (_context.Clientes != null) 
            {
                Clientes= await _context.Clientes.ToListAsync();
            }
        }
    }
}
