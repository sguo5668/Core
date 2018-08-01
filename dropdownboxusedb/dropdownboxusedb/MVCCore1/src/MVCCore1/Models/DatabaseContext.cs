using Microsoft.EntityFrameworkCore;

namespace MVCCore1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }
        public DbSet<CountryMaster> CountryMaster { get; set; }
    }
}