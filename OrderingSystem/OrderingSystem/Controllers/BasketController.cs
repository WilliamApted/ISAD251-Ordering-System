using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Ordering;
using OrderingSystem.SharedFunctions;

namespace OrderingSystem.Controllers
{
    public class BasketController : Controller
    {

        private readonly DatabaseContext _context;
        public BasketController(DatabaseContext context)
        {
            _context = context;
        }
        
       
    }
}