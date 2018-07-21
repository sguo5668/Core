using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Events
{
	public class InventoryItemDeactivated : Event
	{
		public readonly Guid Id;

		public InventoryItemDeactivated(Guid id)
		{
			Id = id;
		}
	}
}
