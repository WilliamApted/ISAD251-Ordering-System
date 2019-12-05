using OrderingSystem.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.API
{
    public class ApiOrder
    {
        public Order order { get; set; }
        public List<OrderItem> items { get; set; }
    }
}
