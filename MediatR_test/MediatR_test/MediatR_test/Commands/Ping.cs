using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace MediatR_test.Commands
{
	public class Ping : IRequest<string>
	{
	}
}
