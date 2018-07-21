using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Events
{
	public class ItemsRemovedFromInventory : Event
	{
		public Guid Id;
		public readonly int Count;

		public ItemsRemovedFromInventory(Guid id, int count)
		{
			Id = id;
			Count = count;
		}
	}
}
