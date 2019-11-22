using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Items
{
    public class BasketItemModel
    {
        
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
