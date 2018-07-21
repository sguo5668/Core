using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Models
{
	public static class PersonRepository
	{
		public static readonly List<Person> People = new List<Person>()
		{
			new Person { Id = 1, Name = "Simon", City = "Reading", IsUKResident = true },
			new Person { Id = 2, Name = "Peter", City = "London", IsUKResident = true },
			new Person { Id = 3, Name = "Sarah", City = "New York", IsUKResident = false, Country = "USA" },
			new Person { Id = 4, Name = "Kate", IsUKResident = false, Country = "New Zealand" },
			new Person { Id = 5, Name = "Hannah", City = "Sydney", IsUKResident = false, Country = "Australia"} ,
			new Person { Id = 6, Name = "Paul", City = "Bangalore", IsUKResident = false, Country = "India" }
		};
	}
}
