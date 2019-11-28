using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Items
{
    public class ConfirmOrderModel
    {
        [StringLength(80, ErrorMessage = "Maximum name length is 50 characters.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Incorrect table number.")]
        public int TableNumber { get; set; }
    }
}
