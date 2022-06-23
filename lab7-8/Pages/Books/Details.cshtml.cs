#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab7_8.Data;
using lab7_8.Models;

namespace lab7_8.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly lab7_8.Data.lab7_8Context _context;

        public DetailsModel(lab7_8.Data.lab7_8Context context)
        {
            _context = context;
        }

        public lab7_8.Models.Books Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _context.Books.FirstOrDefaultAsync(m => m.ID == id);

            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
