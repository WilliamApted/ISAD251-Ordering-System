using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Models.Database;
using OrderingSystem.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class OrderManage
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int OrderId { get; set; }

        public Order order { get; set; } 

        public OrderManage() 
        { 
        
        
        }

        public OrderManage(int orderId, string name)
        {
            this.OrderId = orderId;
            this.Name = name;
        }

        public OrderManage(string cookieBasket)
        {
            try
            {
                //Trys to desearlise the value held in the cookie, if success sets the item list.
                OrderManage order = JsonSerializer.Deserialize<OrderManage>(cookieBasket);
                Name = order.Name;
                OrderId = order.OrderId;
            }
            catch
            {   
            }
        }
        public void GetOrder(DatabaseContext context) 
        {
            order = context.Order.Where(findOrder => findOrder.Id == OrderId && findOrder.Name == Name).FirstOrDefault();
        }

        public void SaveEdit(Basket basket, DatabaseContext context) 
        {
            //Check order exists and is correct.
            GetOrder(context);

            if (order != null)
            {
                //Delete current orderitems for the order
                SqlParameter orderParam = new SqlParameter("@query", order.Id);
                context.Database.ExecuteSqlRaw("DeleteOrderItems @query", orderParam);

                context.OrderItem.AddRange(basket.items.ConvertAll(basketItem => new OrderItem { ItemId = basketItem.ItemId, Quantity = basketItem.Quantity, OrderId = order.Id }));
                context.SaveChanges();
            }
            //Return success or fail.

        }

        //Gets list of all items in the basket with full details.
        public List<ItemDetailsModel> GetItemDetails(DatabaseContext context)
        {
            //using (context)
            {
                List<ItemDetailsModel> itemDetails = new List<ItemDetailsModel>();

                foreach (OrderItem basketItem in context.OrderItem.Where(item => item.OrderId == OrderId).ToList())
                {
                    //Get the Item from the database - create new object to hold details
                    Item itemDetail = context.Item.Where(item => item.Id == basketItem.ItemId).First();
                    itemDetails.Add(new ItemDetailsModel(itemDetail, basketItem.Quantity));
                }
                return itemDetails;
            }
        }

        public bool CancelOrder(DatabaseContext context)
        {
            GetOrder(context);

            if (order != null)
            {
                //stored procedure to remove an order, so delete all orderItems with X id and then the order.
                SqlParameter deleteQuery = new SqlParameter("@query", OrderId);
                int result = context.Database.ExecuteSqlRaw("DeleteOrder @query", deleteQuery);
                if (result > 0) 
                {
                    //Successfully deleted/canceled the order.
                    return true;
                }
            }
            //Not deleted/canceled an order.
            return false;
        }

        public string GetSerialised()
        {
            return JsonSerializer.Serialize(new OrderManage(this.OrderId, this.Name));
        }
    }
}
