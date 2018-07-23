using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatR_test.Events;
using Microsoft.Extensions.Logging;

namespace MediatR_test.Handlers
{
	public class Handler2 : INotificationHandler<SomeEvent>
	{
		private readonly ILogger<Handler2> _logger;

		public Handler2(ILogger<Handler2> logger)
		{
			_logger = logger;
		}
		public void Handle(SomeEvent notification)
		{
			_logger.LogWarning($"Handled: {notification.Message}");
		}
	}
}
