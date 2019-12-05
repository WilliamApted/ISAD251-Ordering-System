using OrderingSystem.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public void GetOrder(DatabaseContext context) 
        {
            using (context)
            {
                order = context.Order.Where(findOrder => findOrder.Id == OrderId && findOrder.Name == Name).First();
            }
        }

        //Gets list of all items in the basket with full details.
        public List<ItemDetailsModel> GetItemDetails(DatabaseContext context)
        {
            using (context)
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





    }
}
