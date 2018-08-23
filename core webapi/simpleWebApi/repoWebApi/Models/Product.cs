using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace repoWebApi.Models
{
	public class Product
	{
		public int Id { get; set; }

		public bool IsDiscontinued { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }
	}
}
