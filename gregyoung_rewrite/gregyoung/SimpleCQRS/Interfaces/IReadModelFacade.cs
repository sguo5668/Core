using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCQRS.DTO;

namespace SimpleCQRS.Interfaces
{
	public interface IReadModelFacade
	{
		IEnumerable<InventoryItemListDto> GetInventoryItems();
		InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
	}
}
