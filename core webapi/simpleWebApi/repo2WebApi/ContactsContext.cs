using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using repo2WebApi.Models;

namespace repo2WebApi
{
	public class ContactsContext : DbContext
	{
		public ContactsContext(DbContextOptions<ContactsContext> options)
			: base(options) { }
		public ContactsContext() { }
		public DbSet<Contacts> Contacts { get; set; }
	}
}
