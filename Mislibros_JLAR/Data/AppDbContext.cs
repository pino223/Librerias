using Microsoft.EntityFrameworkCore;
using Mislibros_JLAR.Data.Models;

namespace Mislibros_JLAR.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {

        }
        public DbSet<Books> Books { get; set; }
    }
}
