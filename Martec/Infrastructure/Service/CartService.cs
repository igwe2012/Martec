using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Martec.Infrastructure.Service
{
    public class CartService
    {
        private static string Key = "cart";

        public int Quantities { get; private set; }

        public List<ItemModel> GetCartItems()
        {
            if(HttpContext.Current.Session[Key] == null)
            {
                HttpContext.Current.Session[Key] = new List<ItemModel>();
            }
            return HttpContext.Current.Session[Key] as List<ItemModel>;
        }

        public void AddToCart(ProductModel product)
        {
            var items = GetCartItems();
            var cartItems = items.FirstOrDefault(i => i.ProductId == product.ProductId);
            if(cartItems == null)
            {
                items.Add(new ItemModel
                {
                    ProductId = product.ProductId,
                    Product = product,
                    UnitPrice = product.UnitPrice,
                    ProductName = product.ProductName,
                    Size = product.Size
                    
                    
                   // Quantity = 1
                });
            }
          //  else
            //{
              //  cartItems.Quantity += 1;
            //}
            SaveChanges(items);
        }
        public void UpdateCart(int productId,int quantity)
        {
            var items = GetCartItems();
            var cartItems = items.FirstOrDefault(i => i.ProductId == productId);
            if (cartItems != null)
            {
                 cartItems.Quantity = quantity;
            }
            SaveChanges(items);
           
        }

        private void SaveChanges(List<ItemModel> items)
        {
            HttpContext.Current.Session[Key] = items;
        }

        public void RemoveCart(int Id)
        {
            var items = GetCartItems();
            var cartItems = items.FirstOrDefault(i => i.ProductId == Id);
            if (cartItems != null  )
            {
               // if(cartItems.Quantity > 0)
               // {
               //     cartItems.Quantity -= 1;
               // }
               // else
               // {
                    items.Remove(cartItems);
               // }
                
            }
        }
        public void ClearCart()
        {
            SaveChanges(new List<ItemModel>());
        }

    }
}