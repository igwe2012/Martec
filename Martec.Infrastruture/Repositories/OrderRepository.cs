using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Models;
using Martec.Infrastruture.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DbContext _context;

        public OrderRepository(DbContext context)
        {
            _context = context;
        }

        public OrderModel CreateOrder(int userId, ItemModel[] items)
        {
            if (userId <= 0) throw new Exception("Invalid UserId");

            //Create User
            var order = new Order
            {
                CreatedDate = DateTime.Now,
                UserId = userId,
            };
            //Add Items to Order
            foreach (var item in items)
            {
                order.Items.Add(new Item
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    CreatedDate = DateTime.Now,
                    PRoductName = item.ProductName,
                    Size = item.Size                   
                });
            }
            //Add Order to Context
            _context.Set<Order>().Add(order);
            //Save Order
            _context.SaveChanges();

            var model = new OrderModel
            {
                CreatedDate = order.CreatedDate,
                OrderId = order.OrderId,
                UserId = order.UserId,
                Items = items           
            };
            return model;
        }

        public OrderDeliveryModel DeliveryAddress(int orderid)
        {
            var query = from order in _context.Set<Order>()
                        where order.OrderId == orderid
                        select new
                        {
                            OrderDelivery = order.OrderDeliveries.FirstOrDefault()
                        };
            var record = query.FirstOrDefault();
            var data = new OrderDeliveryModel
            {
                CreatedDate = record.OrderDelivery.CreatedDate,
                DeliveryAddress = record.OrderDelivery.DeliveryAddress,
                OrderDeliveryId = record.OrderDelivery.OrderDeliveryId,
                FullName = record.OrderDelivery.FullName,
                PhoneNumber = record.OrderDelivery.PhoneNumber
            };
            return data;
        }

        public OrderModel[] GetOrders()
        {
            var query = from order in _context.Set<Order>()
                        select new
                        {
                            order,
                            Item = order.Items
                        };
            var records = query.ToArray();

            var data = from record in records
                       select new OrderModel
                       {                           
                           CreatedDate = record.order.CreatedDate,
                           OrderId = record.order.OrderId,
                           UserId = record.order.UserId,
                           Items = (from item in record.Item
                                    select new ItemModel
                                    {
                                        Quantity = item.Quantity,
                                        CreatedDate = item.CreatedDate,
                                        OrderId = item.OrderId,
                                        UnitPrice = item.UnitPrice,
                                        ProductId = item.ProductId,
                                    }).ToArray()
                       };
            return data.ToArray();
        }

        public ItemModel[] ItemInOrder(int orderId)
        {
            var query = from order in _context.Set<Order>()
                        where order.OrderId == orderId
                        select new
                        {
                            Item = order.Items
                        };
            var record = query.FirstOrDefault();

            var data = from item in record.Item.ToArray()
                       select new ItemModel
                       {
                           Quantity = item.Quantity,
                           CreatedDate = item.CreatedDate,
                           OrderId = item.OrderId,
                           UnitPrice = item.UnitPrice,
                           ProductId = item.ProductId,
                           ProductName = item.PRoductName,
                           Size = item.Size
                       };
            return data.ToArray();
        }

        public OrderDeliveryModel StoreDeliveryDetails(OrderDeliveryModel model, int orderId)
        {
            if (orderId <= 0) throw new Exception("Invalid Order");

            var delivery = new OrderDelivery()
            {
                CreatedDate = DateTime.Now,
                DeliveryAddress = model.DeliveryAddress,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                OrderId = orderId
                
            };
            _context.Set<OrderDelivery>().Add(delivery);
            _context.SaveChanges();

            model.OrderDeliveryId = delivery.OrderDeliveryId;

            return model;
        }
    }
}

