using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Events
{
	public class InventoryItemRenamed : Event
	{
		public readonly Guid Id;
		public readonly string NewName;

		public InventoryItemRenamed(Guid id, string newName)
		{
			Id = id;
			NewName = newName;
		}
	}
}
