using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class BasketItemModel
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public BasketItemModel() 
        {
        
        }       
        public BasketItemModel(int itemId, int quantity) 
        {
            this.ItemId = itemId;
            this.Quantity = quantity;
        }
    }
}
