using System;
using System.Collections.Generic;
using SimpleCQRS.DTO;
using SimpleCQRS.Interfaces;
using System.Linq;

namespace SimpleCQRS
{
    
    public class ReadModelFacade : IReadModelFacade
    {
        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return BullShitDatabase.list;
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return BullShitDatabase.details[id];
        }
    }


}
