using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatR_test.Events;

namespace MediatR_test.Handlers
{
	public class PingHandler3 : IRequestHandler<Ping, string>
	{
		public string Handle(Ping request)
		{
			return "Pong 3";
		}
	}
}
