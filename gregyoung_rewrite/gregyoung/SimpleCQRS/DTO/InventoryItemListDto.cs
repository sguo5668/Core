using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCQRS.DTO
{
	public class InventoryItemListDto
	{
		public Guid Id;
		public string Name;

		public InventoryItemListDto(Guid id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
