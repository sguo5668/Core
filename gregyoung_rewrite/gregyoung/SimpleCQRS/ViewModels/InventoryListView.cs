using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleCQRS.DTO;
using SimpleCQRS.Events;
using SimpleCQRS.Interfaces;

namespace SimpleCQRS.ViewModels
{
	public class InventoryListView : ICommandHandler<InventoryItemCreated>, ICommandHandler<InventoryItemRenamed>, ICommandHandler<InventoryItemDeactivated>
	{
		public void Handle(InventoryItemCreated message)
		{
			BullShitDatabase.list.Add(new InventoryItemListDto(message.Id, message.Name));
		}

		public void Handle(InventoryItemRenamed message)
		{
			var item = BullShitDatabase.list.Find(x => x.Id == message.Id);
			item.Name = message.NewName;
		}

		public void Handle(InventoryItemDeactivated message)
		{
			BullShitDatabase.list.RemoveAll(x => x.Id == message.Id);
		}
	}
}
