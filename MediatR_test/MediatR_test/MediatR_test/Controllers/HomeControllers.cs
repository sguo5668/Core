using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatR_test.Events;
using MediatR_test.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MediatR_test.Controllers
{
	public class HomeController : Controller
	{

		private readonly IMediator _mediator;

		public HomeController(IMediator mediator)
		{
			this._mediator = mediator;
		}
		public async Task<IActionResult> Index()
		{
			await _mediator.Publish(new SomeEvent("Hello World"));
			return View();
		}
		// more code omitted


		public async Task<IActionResult> About()
		{
			// example of request/response messages
			var result = await _mediator.Send(new Ping());

			// only handle one and only one

			//you need multiple handlers to react to the same message you should take a look at MediatR notifications.
			ViewData["Message"] = $"Your application description page: {result}";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterUser registerUser)
		{
			bool registered = await _mediator.Send(registerUser);
			return View();
		}

//		if you’re communicating with external systems(database, CRM, SMTP servers) and really need resilience even if those services go down, you might consider going even further than MediatR and use a service bus.

//For example, you could implement queues using Azure Service Bus, RabbitMQ etc.

//This takes the decoupling one step further and ensures your “notifications” can be persisted and retried in the event of any external system “flakiness”.

//The good thing is, if you use MediatR in the first place, switching to a messaging/queuing approach is a simple exercise.
	}
}
