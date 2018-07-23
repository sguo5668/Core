using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_test.Commands
{
	public class RegisterUser : IRequest<bool>
	{
		public string EmailAddress { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
