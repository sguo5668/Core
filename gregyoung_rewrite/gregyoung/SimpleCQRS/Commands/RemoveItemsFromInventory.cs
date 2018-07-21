﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Commands
{
	public class RemoveItemsFromInventory : Command
	{
		public Guid InventoryItemId;
		public readonly int Count;
		public readonly int OriginalVersion;

		public RemoveItemsFromInventory(Guid inventoryItemId, int count, int originalVersion)
		{
			InventoryItemId = inventoryItemId;
			Count = count;
			OriginalVersion = originalVersion;
		}
	}
}
