using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRozar.Model
{
    public class AppDbContest:DbContext
    {
        public AppDbContest(DbContextOptions<AppDbContest> options):base(options)
        {
            
        }

        public DbSet<Book>Book { get; set; }
    }
}
