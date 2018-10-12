using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookService.Controllers
{

	[Route("api/[controller]")]
	public class BooksController : Controller
	{
		private BookServiceContext db = new BookServiceContext();
		[HttpGet]
		// GET: api/Books
		public IQueryable<BookDTO> GetBooks()
		{
			var books = from b in db.Books
						select new BookDTO()
						{
							Id = b.Id,
							Title = b.Title,
							AuthorName = b.Author.Name
						};

			return books;
		}

		// GET: api/Books/5
		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(BookDetailDTO))]
		public async Task<IActionResult> GetBook(int id)
		{
			var book = await db.Books.Include(b => b.Author).Select(b =>
				new BookDetailDTO()
				{
					Id = b.Id,
					Title = b.Title,
					Year = b.Year,
					Price = b.Price,
					AuthorName = b.Author.Name,
					Genre = b.Genre
				}).SingleOrDefaultAsync(b => b.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			return Ok(book);
		}

		// PUT: api/Books/5
	 
			[HttpPut]
		[ProducesResponseType(200, Type = typeof(void))]
		public async Task<IActionResult> PutBook(int id, Book book)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != book.Id)
			{
				return BadRequest();
			}

			db.Entry(book).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BookExists(id))
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
		// POST: api/Books
		[ProducesResponseType(200, Type = typeof(Book))]
		public async Task<IActionResult> PostBook(Book book)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.Books.Add(book);
			await db.SaveChangesAsync();

			// Load author name
			db.Entry(book).Reference(x => x.Author).Load();

			var dto = new BookDTO()
			{
				Id = book.Id,
				Title = book.Title,
				AuthorName = book.Author.Name
			};

			return CreatedAtRoute("DefaultApi", new { id = book.Id }, dto);
		}


		[HttpDelete]
		// DELETE: api/Books/5
		[ProducesResponseType(200, Type = typeof(Book))]
		public async Task<IActionResult> DeleteBook(int id)
		{
			Book book = await db.Books.FindAsync(id);
			if (book == null)
			{
				return NotFound();
			}

			db.Books.Remove(book);
			await db.SaveChangesAsync();

			return Ok(book);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool BookExists(int id)
		{
			return db.Books.Count(e => e.Id == id) > 0;
		}
	}
}
