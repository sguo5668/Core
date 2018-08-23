using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace simpleWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {


		//private List<Product> products = new List<Product>
		//{

		//	new Product  { Id=1, Name="test1", Description="test desc1" },

		//	new Product  { Id=2, Name="test2", Description="test desc2" },

		//	new Product  { Id=3, Name="test3", Description="test desc3" }

		//};


		//private List<Product> products = new List<Product>
		//{

		//	new Product() { Id=1, Name="test1", Description="test desc1" },

		//	new Product() { Id=2, Name="test2", Description="test desc2" },

		//	new Product() { Id=3, Name="test3", Description="test desc3" }

		//};


		private List<Product> products = new List<Product> ( new []
		{

			new Product() { Id=1, Name="test1", Description="test desc1" },

			new Product() { Id=2, Name="test2", Description="test desc2" },

			new Product() { Id=3, Name="test3", Description="test desc3" }

		} );


		// GET api/Products
		[HttpGet]
        public List<Product> GetAll()
        {
            return products.ToList();
        }

		// GET api/Products/5
		[HttpGet("{id}")]
        public Product Get(int id)
        {
            return products.SingleOrDefault(p=>p.Id==id);
        }

		// POST api/Products
		[HttpPost]
		public IActionResult Post([FromBody]Product product)
		{

			if (!ModelState.IsValid) {

				return BadRequest(ModelState);
			}

 
				products.Add(product);
				return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
		 
		}



		// no response

		//public Void Post([FromBody]Product product)
		//{

 		//		products.Add(product);
 
		//}



		// PUT api/Products/5
		[HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {

			var productToUpdate = products.SingleOrDefault(p => p.Id == id);

			if (productToUpdate != null)
			{
				products[id].Name = product.Name;
				products[id].Description = product.Description;
				return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
			}

			return NoContent();




		}

		// DELETE api/Products/5
		[HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
