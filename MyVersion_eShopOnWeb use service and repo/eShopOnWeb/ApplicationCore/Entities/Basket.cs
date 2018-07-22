using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Basket : BaseEntity
    {


        public string BuyerId { get; set; }


        private readonly List<BasketItem> _items = new List<BasketItem>();

        public IEnumerable<BasketItem> Items => _items.ToList();


        public void AddItem(int catalogItemId, decimal unitPrice, int quantity = 1)
        {

        }

    }

}
