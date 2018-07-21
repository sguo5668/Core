using System;
using System.Collections.Generic;

namespace ConsoleAppCodeFirst
{
    class Program
    {
		static void Main(string[] args)
		{
			using (var context = new EFCoreDemoContext())
			{
				var author = new Author
				{
					FirstName = "William",
					LastName = "Shakespeare",
					Books = new List<Book>
					{
						new Book { Title = "Hamlet"},
						new Book { Title = "Othello" },
						new Book { Title = "MacBeth" }
					}
				};
				context.Add(author);
				context.SaveChanges();



				Console.WriteLine();
				Console.WriteLine("All records in database:");
				foreach (var book in context.Books)
				{
					Console.WriteLine(book.Title);
				}

			}
		}
	}
}
