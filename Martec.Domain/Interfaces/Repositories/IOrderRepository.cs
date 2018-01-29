using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        OrderModel CreateOrder(int userId, ItemModel[] items);
        OrderModel[] GetOrders();
        ItemModel[] ItemInOrder(int orderId);
        OrderDeliveryModel StoreDeliveryDetails(OrderDeliveryModel model, int orderId);
        OrderDeliveryModel DeliveryAddress(int orderid);
    }
}
