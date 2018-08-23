using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
using DemoApp.Models;

namespace DemoApp.Controllers
{
	[Produces("application/json")]
	[Route("api/person")]
	public class PersonController : Controller
	{
		private List<Person> People;
		public PersonController()
		{
			People = new List<Person>()
				{
		new Person() {Id=1, Name = "Fred Blogs", Email="fred.blogs@someemail.com" },
		new Person() {Id=2, Name = "James Smith", Email="james.smith@someemail.com" },
		new Person() {Id=3, Name = "Jerry Jones", Email="jerry.jones@someemail.com" }
				};
		}


		// GET: api/person
		[HttpGet]
		public IActionResult Get()
		{
			return new ObjectResult(People);
		}


		// GET api/person/id
		[HttpGet("{id}", Name = "GetPerson")]
		public IActionResult Get(int id)
		{
			Person person = (from p in People where p.Id == id select p).FirstOrDefault();
			if (person == null)
			{
				return NotFound();
			}
			else
			{
				return new ObjectResult(person);
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody]Person person)
		{
			if (person == null)
			{
				return BadRequest();
			}
			int nextId = (from p in People select p.Id).Max() + 1;
			person.Id = nextId;
			People.Add(person);
			return CreatedAtRoute("GetPerson", new { id = nextId }, person);
		}


	}
}