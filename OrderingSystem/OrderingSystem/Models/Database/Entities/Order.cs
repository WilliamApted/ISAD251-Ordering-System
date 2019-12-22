using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Table { get; set; }
        public DateTime dateTime { get; set; }

    }
}
