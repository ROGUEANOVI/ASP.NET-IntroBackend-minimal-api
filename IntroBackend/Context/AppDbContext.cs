using IntroBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace IntroBackend.Context
{
    public class AppDbContext: DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Beer> Beer { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Stock> Stock { get; set; }

    }
}
