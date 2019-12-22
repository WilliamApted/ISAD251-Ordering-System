using OrderingSystem.Models.Database;
using OrderingSystem.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class ItemDetailsModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public ItemDetailsModel() 
        {
        
        }

        public ItemDetailsModel(Item item, int quantity) 
        {
            this.ItemId = item.Id;
            this.Name = item.Name;
            this.ImgUrl = item.ImageUrl;
            this.Price = item.Price;
            this.Quantity = quantity;
        }
    }
}
