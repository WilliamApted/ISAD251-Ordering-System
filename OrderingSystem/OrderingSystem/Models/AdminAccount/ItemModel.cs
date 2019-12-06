using OrderingSystem.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.AdminAccount
{
    public class ItemModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public bool Available { get; set; }


        public ItemModel() { }

        public ItemModel(Item item) 
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            ImageUrl = item.ImageUrl;
            Price = item.Price;
            Category = item.Category;
            Available = item.Available;        
        }
        
        public void Add(DatabaseContext context) 
        {
            context.Item.Add(new Item(this));
            context.SaveChanges();
        }

        public void Update(DatabaseContext context) 
        {
            Item item = context.Item.First(select => select.Id == Id);
            item.UpdateModel(this);
            context.SaveChanges();
        }
    }
}
