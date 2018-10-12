using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookService
{
	public class BookServiceContext : DbContext
	{
		// You can add custom code to this file. Changes will not be overwritten.
		// 
		// If you want Entity Framework to drop and regenerate your database
		// automatically whenever you change your model schema, please use data migrations.
		// For more information refer to the documentation:
		// http://msdn.microsoft.com/en-us/data/jj591621.aspx

		public BookServiceContext()  
		{
		 //	this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
		}

		public DbSet <Author> Authors { get; set; }

		public DbSet<Book> Books { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning// To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookServiceContext;Trusted_Connection=True;");
			}
		}

	}
}
