using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIS.Data;
using CIS.Models;

namespace CIS.Pages
{
    public class redactModel : PageModel
    {
        private readonly CIS.Data.ApplicationDbContext _context;

        public redactModel(CIS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Games Games { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Games.Add(Games);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
