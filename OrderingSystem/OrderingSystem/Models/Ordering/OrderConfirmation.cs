using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class OrderConfirmation
    {
        [Required]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "Maximum name length is 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The table number is required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Incorrect table number.")]
        public int? TableNumber { get; set; }




        //Confirm order here
    }
}
