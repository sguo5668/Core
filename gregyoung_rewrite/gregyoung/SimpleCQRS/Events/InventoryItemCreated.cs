using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Events
{
	public class InventoryItemCreated : Event
	{
		public readonly Guid Id;
		public readonly string Name;
		public InventoryItemCreated(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
