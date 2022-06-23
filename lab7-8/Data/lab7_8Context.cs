#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab7_8.Models;

namespace lab7_8.Data
{
    public class lab7_8Context : DbContext
    {
        public lab7_8Context (DbContextOptions<lab7_8Context> options)
            : base(options)
        {
        }

        public DbSet<lab7_8.Models.Books> Books { get; set; }
    }
}
