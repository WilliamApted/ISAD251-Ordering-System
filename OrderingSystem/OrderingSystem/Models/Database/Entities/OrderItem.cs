using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database
{
    public class OrderItem
    {
        [Key]
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
