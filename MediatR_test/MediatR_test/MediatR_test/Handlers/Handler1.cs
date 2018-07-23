using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatR_test.Events;
using Microsoft.Extensions.Logging;

namespace MediatR_test.Handlers
{
	public class Handler1 : INotificationHandler<SomeEvent>
	{
		private readonly ILogger<Handler1> _logger;

		public Handler1(ILogger<Handler1> logger)
		{
			_logger = logger;
		}
		public void Handle(SomeEvent notification)
		{
			_logger.LogWarning($"Handled: {notification.Message}");
		}
	}
}
