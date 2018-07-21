using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace Basics
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			//  optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Basics;Trusted_Connection=True;ConnectRetryCount=0");

			optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BasicsDatabase"].ConnectionString);
		}
	}


}
 