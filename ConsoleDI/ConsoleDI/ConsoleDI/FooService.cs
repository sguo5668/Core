﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ConsoleDI
{
	public class FooService : IFooService
	{
		private readonly ILogger<FooService> _logger;
		public FooService(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<FooService>();
		}

		public void DoThing(int number)
		{
			_logger.LogInformation($"Doing the thing {number}");
		}
	}
}
