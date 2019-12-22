using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Database.Entities
{
    public class View_OrderOverview
    {
        [Key]
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int Table { get; set; }
    }
}
