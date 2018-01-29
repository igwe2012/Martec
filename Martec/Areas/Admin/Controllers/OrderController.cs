using Martec.Domain.Managers;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Martec.Web.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private OrderManager _order;

        public OrderController()
        {
            var order = new OrderManager(new OrderRepository(new MartecEntities()));
            _order = order;
        }
        // GET: Admin/Order
        public ActionResult Index()
        {
            try
            {
                //Get Orders
                var order = _order.AllOrders();
                return View(order);
            }
            catch(Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View();
            }

        }
        public ActionResult Details(int Id)
        {
            try
            {
                //Get items in Order
                var order = _order.OrderItem(Id);

                return View(order);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View();
            }

        }
        public ActionResult DeliveryAddress(int Id)
        {
            try
            {
                //Get OrderDelivery in Order
                var order = _order.DeliveryDetails(Id);

                return View(order);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View();
            }

        }
    }
}