﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Interfaces
{
	public interface IEventStore
	{
		void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
		List<Event> GetEventsForAggregate(Guid aggregateId);
	}

}
