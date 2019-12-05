using OrderingSystem.Models.Database;
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
        public int TableNumber { get; set; }

        public OrderConfirmation() 
        {
        
        }

        //Confirm order here
        public void NewOrder(BasketModel basket, DatabaseContext context)
        {
            Order newOrder = new Order() { Name = this.Name, Table = this.TableNumber, dateTime = DateTime.Now };
            context.Order.Add(newOrder);
            context.SaveChanges();

            context.OrderItem.AddRange(basket.items.ConvertAll(basketItem => new OrderItem { ItemId = basketItem.ItemId, Quantity = basketItem.Quantity, OrderId = newOrder.Id }));
            context.SaveChanges();
        }

    }
}
