using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class ViewOrderModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int OrderNumber { get; set; }
    }
}
