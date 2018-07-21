using System.Linq;
 

namespace NSK
{
	public interface IDatabase
	{
		IQueryable<Category> Categories { get; }

 
		IQueryable<Product> Products { get; }

		IQueryable<Supplier> Suppliers { get; }

 
 
	}
}
