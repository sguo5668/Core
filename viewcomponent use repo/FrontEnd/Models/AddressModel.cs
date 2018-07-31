using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class AddressModel
    {
		public int Id { get; set; }
		public bool Domestic { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public StateModel State { get; set; }
		public string Zip { get; set; }
		public string ZipExt { get; set; }
		public int AddressType { get; set; }
		public int PersonId { get; set; }

	}
}
