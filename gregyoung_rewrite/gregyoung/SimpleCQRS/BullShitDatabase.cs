using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCQRS.DTO;

namespace SimpleCQRS
{
	public static class BullShitDatabase
	{
		public static Dictionary<Guid, InventoryItemDetailsDto> details = new Dictionary<Guid, InventoryItemDetailsDto>();
		public static List<InventoryItemListDto> list = new List<InventoryItemListDto>();
	}
}
