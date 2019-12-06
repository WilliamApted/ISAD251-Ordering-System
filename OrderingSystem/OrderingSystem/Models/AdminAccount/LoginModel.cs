using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingSystem.Models.AdminAccount
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
