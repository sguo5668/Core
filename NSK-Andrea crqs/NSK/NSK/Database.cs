using System.Linq;
 
using Microsoft.EntityFrameworkCore;
using System;

namespace NSK
{
	public class Database : IDatabase
	{
		private NorthwindContext Context;

		public Database(NorthwindContext context)
		{
			Context = context ?? throw new ArgumentNullException(nameof(context));
			Context.ChangeTracker.AutoDetectChangesEnabled = false;
		}

		public IQueryable<Category> Categories
		{
			get
			{
				return Context.Categories;
			}
		}

 

		public IQueryable<Product> Products
		{
			get
			{
				return Context.Products;
			}
		}

		public IQueryable<Supplier> Suppliers
		{
			get
			{
				return Context.Suppliers;
			}
		}

 
	 
	}
}
