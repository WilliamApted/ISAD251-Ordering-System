using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class BasketItemModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
