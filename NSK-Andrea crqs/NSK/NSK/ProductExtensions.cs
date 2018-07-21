using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSK
{
	public static class ProductExtensions
	{
		public static IQueryable<Product> ByCategory(this IQueryable<Product> products, int categoryId)
		{
			return products.ForSale().Where(p => p.CategoryId == categoryId);
		}

		public static IQueryable<Product> ByCategory(this IQueryable<Product> products, string categoryName)
		{
			return products.ForSale().Where(p => p.Category.Name == categoryName);
		}

		public static IQueryable<Product> BySupplier(this IQueryable<Product> products, int supplierId)
		{
			return products.ForSale().Where(p => p.SupplierId == supplierId);
		}

		public static IQueryable<Product> ForSale(this IQueryable<Product> products)
		{
			return products.Where(p => !p.IsDiscontinued && p.UnitPrice != null);
		}

 
	}
}
