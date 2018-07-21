using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.Commands
{
	public class DeactivateInventoryItem : Command
	{
		public readonly Guid InventoryItemId;
		public readonly int OriginalVersion;

		public DeactivateInventoryItem(Guid inventoryItemId, int originalVersion)
		{
			InventoryItemId = inventoryItemId;
			OriginalVersion = originalVersion;
		}
	}
}
