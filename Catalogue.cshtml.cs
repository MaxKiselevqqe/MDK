using CIS.Data;
using CIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CIS.Pages
{
    public class CatalogueModel : PageModel
    {
        public List<Games> Games { get; set; }
        
        private ApplicationDbContext _context;
        
        public CatalogueModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Games=_context.Games.ToList();
        }
    }
}
