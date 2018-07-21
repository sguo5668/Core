using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSK.ViewModels;
using NSK.WorkerServices;

namespace NSK.Controllers
{
	public class CatalogController : Controller
	{
		public CatalogControllerWorkerServices WorkerServices { get; private set; }

		public CatalogController(CatalogControllerWorkerServices workerServices)
		{
			this.WorkerServices = workerServices ?? throw new ArgumentNullException("workerServices");
		}

		[HttpGet]
		public IActionResult ProductDetail(int productId)
		{
			var model = WorkerServices.GetProductDetailViewModel(productId);
			return View(model);
		}

		[HttpGet]
		public IActionResult GetRelatedProducts(int productId)
		{
			var model = WorkerServices.GetRelatedProductsViewModel(productId);
			return Json(model);
		}

		[HttpGet]
		public IActionResult ProductsByCategory(int categoryId)
		{
			var model = WorkerServices.GetProductsByCategoryViewModel(categoryId);
			return View(model);
		}

		[HttpGet]
		public IActionResult ProductsBySupplier(int supplierId)
		{
			var model = WorkerServices.GetProductsBySupplierViewModel(supplierId);
			if (model == null)
				return new StatusCodeResult(400);
			return View(model);
		}

 

		[HttpGet]
		public IActionResult Search()
		{
			var model = WorkerServices.GetSearchViewModel();
			return View(model);
		}

		[HttpPost]
		public IActionResult Search(SearchViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			model = WorkerServices.PostSearchViewModel(model);
			return View(model);
		}
	}
}
