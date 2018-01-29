using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Managers
{
    public class OrderManager
    {
        private IOrderRepository _repo;

        public OrderManager(IOrderRepository repo)
        {
            _repo = repo;
        }
        public OrderModel PlaceOrder(int userId,ItemModel[] items)
        {
            if (items == null) throw new Exception("There is no item in your cart");

            if (items.Any(i => i.Quantity <= 0)) throw new Exception("items cannot have zero or negative quantity");

           return _repo.CreateOrder(userId, items);
        }

        public OrderModel[] AllOrders()
        {
            // Retrieving all Orders
            return _repo.GetOrders();
        }

        public OrderDeliveryModel CreateDeliveryInfo(OrderDeliveryModel model, int orderId)
        {
            // Create delivery details
           return  _repo.StoreDeliveryDetails(model, orderId);
        }

        public OrderDeliveryModel DeliveryDetails(int orderid)
        {
            return _repo.DeliveryAddress(orderid);
        }

        public ItemModel[] OrderItem(int orderId)
        {
            //Getting all the Items in an order
            return _repo.ItemInOrder(orderId);
        }
    }
}
