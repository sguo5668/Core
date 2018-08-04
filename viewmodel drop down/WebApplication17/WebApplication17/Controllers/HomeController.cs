using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication17.Models;

namespace WebApplication17.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

	 MonthViewModel model = new MonthViewModel();



		//private MonthRepository _repository;
		//public HomeController(MonthRepository repository)
		//{
		//	_repository = repository;
		//}
		//public ActionResult Index()
		//{
		//	// We only want a list of months in a single array.
		//	var model = new dbMonthViewModel
		//	{
		//		MonthData = _repository
		//			.GetAll()
		//			.Select(item => item.MonthName).ToArray()
		//	};
		//	return View(model);
		//}

 	return View(model);
	}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
