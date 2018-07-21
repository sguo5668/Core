using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppCodeFirst
{
	public class EFCoreDemoContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
		}
	}
}
