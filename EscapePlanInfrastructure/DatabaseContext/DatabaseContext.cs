using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
