using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
