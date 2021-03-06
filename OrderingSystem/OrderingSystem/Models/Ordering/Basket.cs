﻿using OrderingSystem.Models.Database;
using OrderingSystem.Models.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderingSystem.Models.Ordering
{
    public class Basket
    {

        public List<BasketItem> items { get; set; }

        public Basket() 
        {
            
        }       
        
        //Instantiates the BasketModel with the serialised value in the cookie.
        public Basket(string cookieBasket) 
        {
            try
            {
                //Trys to desearlise the value held in the cookie, if success sets the item list.
                items = JsonSerializer.Deserialize<Basket>(cookieBasket).items;
            }
            catch 
            {
                //If the cookie is empty, null etc. A new empty list will simply be created.
                items = new List<BasketItem>();
            }
        }

        //Adds item to the basket
        public void AddItem(int id) 
        {
            //Check if item exists, if it does, add quantity. If not, add the new item.
            BasketItem basketItem = items.Find(item => item.ItemId == id);

            if (basketItem != null)
                basketItem.Quantity++;
            else
                items.Add(new BasketItem(id, 1));
        }

        //Removes item from the basket
        public void RemoveItem(int id) 
        {
            //Check if item exists, if it does, add quantity. If not, add the new item.
            BasketItem basketItem = items.Find(item => item.ItemId == id);

            //Check if the basket item exists - Then remove from the basket.
            if (basketItem != null)
            {
                basketItem.Quantity--;
                if (basketItem.Quantity < 1)
                    items.Remove(basketItem);
            }

        }

        //Calculates the total basket cost.
        public decimal GetTotal(DatabaseContext context) 
        {
            decimal total = 0;
            foreach (BasketItem basketItem in items)
            {
                Item itemDetail = context.Item.Where(item => item.Id == basketItem.ItemId).First();
                total = total + basketItem.Quantity * itemDetail.Price;
            }
            return total;
        }

        //Gets list of all items in the basket with full details.
        public List<ItemDetailsModel> GetItemDetails(DatabaseContext context)
        {
            List<ItemDetailsModel> itemDetails = new List<ItemDetailsModel>();

            foreach (BasketItem basketItem in items)
            {
                //Get the Item from the database - create new object to hold details
                Item itemDetail = context.Item.Where(item => item.Id == basketItem.ItemId).First();
                itemDetails.Add(new ItemDetailsModel(itemDetail, basketItem.Quantity));
            }
            return itemDetails;
        }

        //Sets the basket to that of a placed order. Used for editing an order.
        public void SetToOrder(DatabaseContext context, int orderId) 
        {
            List<OrderItem> orderItems = context.OrderItem.Where(item => item.OrderId == orderId).ToList();
            items = orderItems.ConvertAll(basketItem => new BasketItem { ItemId = basketItem.ItemId, Quantity = basketItem.Quantity });
        }

        //Serialises the basket so it can be stored in the cookie.
        public string GetSerialised()
        {
            return JsonSerializer.Serialize(this);
        }

        public static bool IsEditing(string cookie) 
        {
            if (cookie != null)
                return true;
            else
                return false;
        }
    }
}
