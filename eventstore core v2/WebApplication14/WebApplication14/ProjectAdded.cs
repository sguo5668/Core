using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14
{
	public class ProjectAdded : IEvent
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}
