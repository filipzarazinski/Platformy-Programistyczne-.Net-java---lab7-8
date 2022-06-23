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
    public class IndexModel : PageModel
    {
        private readonly lab7_8.Data.lab7_8Context _context;

        public IndexModel(lab7_8.Data.lab7_8Context context)
        {
            _context = context;
        }
        public string DateSort { get; set; }
        public string NameSort { get; set; }
        public string GenreSort { get; set; }
        public string AuthorSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFillter { get; set; }
        


        public IList<lab7_8.Models.Books> Books { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            GenreSort = String.IsNullOrEmpty(sortOrder) ? "name2" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "name3" : "";
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "name4" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFillter = searchString;
         

            IQueryable<lab7_8.Models.Books> booksIQ = from s in _context.Books select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                booksIQ = booksIQ.Where(s => s.Title.Contains(searchString));
                                       
            }
         



            switch (sortOrder)
            {
                case "name":
                    booksIQ = booksIQ.OrderByDescending(s => s.Title);
                    break;
                case "name2":
                    booksIQ = booksIQ.OrderBy(s => s.Genre);
                    break;
                case "name3":
                    booksIQ = booksIQ.OrderBy(s => s.Author);
                    break;
                case "name4":
                    booksIQ = booksIQ.OrderBy(s => s.Price);
                    break;
                case "Date":
                    booksIQ = booksIQ.OrderBy(s => s.RelaseDate);
                    break;
                default:
                    booksIQ = booksIQ.OrderBy(s => s.Title);
                    break;

            }


            Books = await booksIQ.AsNoTracking().ToListAsync();
           // Books = await _context.Books.ToListAsync();
        }
    }
}
