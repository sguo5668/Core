using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleAppCodeFirst
{
	public class Book
	{
		public int BookId { get; set; }
		[StringLength(255)]
		public string Title { get; set; }
		public int AuthorId { get; set; }
		public Author Author { get; set; }
	}
}
