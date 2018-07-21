using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using repo.Models;

namespace repo.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			// note: this code sample does not use a separate View Model - 
			// That is a bad practice, so don't copy me :-)
			// I'm just trying to keep the code simple
			var people = PersonRepository.People;
			return View(people);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var person = PersonRepository.People.Where(p => p.Id == id).SingleOrDefault();
			return View(person);
		}

		[HttpPost]
		public ActionResult Edit(Person model)
		{
			if (!ModelState.IsValid)
				return View(model);
			else
			{
				var currentperson = PersonRepository.People.Where(p => p.Id == model.Id).SingleOrDefault();
				currentperson.Name = model.Name;
				currentperson.IsUKResident = model.IsUKResident;
				currentperson.Country = model.Country;
				currentperson.City = model.City;

				return RedirectToAction("Index");
			}
		}
	}
}
