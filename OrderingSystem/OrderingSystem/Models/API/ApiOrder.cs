using OrderingSystem.Models.Database;
using OrderingSystem.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.API
{
    public class ApiOrder
    {
        public View_OrderOverview order { get; set; }
        public List<OrderItem> items { get; set; }
    }
}
