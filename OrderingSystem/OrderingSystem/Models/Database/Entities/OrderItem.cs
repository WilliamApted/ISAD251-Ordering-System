using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database.Entities
{
    public class OrderItem
    {
        [JsonIgnore]
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
