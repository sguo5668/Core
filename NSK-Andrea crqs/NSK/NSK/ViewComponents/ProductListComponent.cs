using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NSK.ViewComponents
{
	public class ProductListViewComponent : ViewComponent
	{
		public IDatabase Database { get; private set; }

		public ProductListViewComponent(IDatabase database)
		{
			Database = database ?? throw new ArgumentNullException(nameof(database));
		}

		public IViewComponentResult Invoke(IEnumerable<NSK.ViewModels.ProductsByCategoryViewModel.Product> products)
		{
			return View(products);
		}
	}
}
