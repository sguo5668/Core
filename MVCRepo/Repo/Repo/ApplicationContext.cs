using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
 
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          //  new AuthorMap(modelBuilder.Entity<Author>());
          //  new BookMap(modelBuilder.Entity<Book>());
	 
		}
    }
}
