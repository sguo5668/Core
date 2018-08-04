using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication16
{
	public class MenuItem
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Url { get; set; }
		public bool OpenInNewWindow { get; set; }
	}
}
