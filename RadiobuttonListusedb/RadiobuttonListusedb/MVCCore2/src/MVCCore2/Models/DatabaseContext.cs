using Microsoft.EntityFrameworkCore;

namespace MVCCore2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
    }
}
