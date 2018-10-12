using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
	public class AuthorsController : Controller
	{
		private BookServiceContext db = new BookServiceContext();

		// GET: api/Authors

		[HttpGet]
		public IQueryable<Author> GetAuthors()
		{
			return db.Authors;
		}

		// GET: api/Authors/5
		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(Author))]

		public async Task<IActionResult> GetAuthor(int id)
		{
			Author author = await db.Authors.FindAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			return Ok(author);
		}

		// PUT: api/Authors/5
		[HttpPut]
		[ProducesResponseType(200, Type = typeof(void))]

		public async Task<IActionResult> PutAuthor(int id, Author author)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != author.Id)
			{
				return BadRequest();
			}

			db.Entry(author).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AuthorExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent(); 
		}


		[HttpPost]
		// POST: api/Authors
		[ProducesResponseType(200, Type = typeof(Author))]


		public async Task<IActionResult> PostAuthor(Author author)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Authors.Add(author);
			await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
		}


		[HttpDelete]
		// DELETE: api/Authors/5
		[ProducesResponseType(200, Type = typeof(Author))]
		public async Task<IActionResult> DeleteAuthor(int id)
		{
			Author author = await db.Authors.FindAsync(id);
			if (author == null)
			{
				return NotFound();
			}

			db.Authors.Remove(author);
			await db.SaveChangesAsync();

			return Ok(author);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool AuthorExists(int id)
		{
			return db.Authors.Count(e => e.Id == id) > 0;
		}
	}
}
