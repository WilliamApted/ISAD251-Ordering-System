using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class BasketItem
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public BasketItem() 
        {
        
        }       
        public BasketItem(int itemId, int quantity) 
        {
            this.ItemId = itemId;
            this.Quantity = quantity;
        }
    }
}
