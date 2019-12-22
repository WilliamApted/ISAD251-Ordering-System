using OrderingSystem.Models.AdminAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
        public bool Available { get; set; }

        public Item() { }

        public Item(ItemModel item) 
        {
            UpdateParams(item);
        }

        public void UpdateModel(ItemModel item) 
        {
            UpdateParams(item);
        }

        private void UpdateParams(ItemModel item) 
        {
            Name = item.Name;
            Description = item.Description;
            ImageUrl = item.ImageUrl;
            Price = item.Price;
            Category = item.Category;
            Available = item.Available;
        }
    }
}
