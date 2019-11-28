using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Table { get; set; }
        public DateTime dateTime { get; set; }
    }
}
