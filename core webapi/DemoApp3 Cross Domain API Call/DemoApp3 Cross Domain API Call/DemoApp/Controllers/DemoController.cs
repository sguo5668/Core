using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApp.Models;
using Microsoft.AspNetCore.Cors;

namespace DemoApp.Controllers
{

	[EnableCors("AnyOrigin")]
	[Produces("application/json")]
	[Route("api/demo")]
	public class DemoController : Controller
	{
 

		// GET: api/person
		[HttpGet]
		public IEnumerable<Customer> Get()
		{
			return new List<Customer>
			{
				new Customer{Id=1,CustomerName="Arun",Address="9th Street",City="Erode",Pincode="637204"},
				new Customer{Id=2,CustomerName="Mohan",Address="Main Road",City="Namakkal",Pincode="637205"},
				new Customer{Id=3,CustomerName="Prapbu",Address="SKV Street",City="Salem",Pincode="637206"},
				new Customer{Id=4,CustomerName="Raja",Address="Raja Street",City="Chennai",Pincode="637207"},
				new Customer{Id=5,CustomerName="Ravi",Address="SMV Street",City="Covai",Pincode="637208"},
				new Customer{Id=6,CustomerName="Santhose",Address="SKM Street",City="Salem",Pincode="637209"},
				new Customer{Id=7,CustomerName="Mugesh",Address="Main Road",City="Trichy",Pincode="637846"},
				new Customer{Id=8,CustomerName="Mani",Address="Mani Street",City="Chennai",Pincode="637245"},
				new Customer{Id=9,CustomerName="Sankar",Address="Sankar Street",City="Tiruchengode",Pincode="637273"},
				new Customer{Id=10,CustomerName="Vignesh",Address="Main Road",City="Kondankattur",Pincode="637201"}
			};
		}


	}
}