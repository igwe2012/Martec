using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Managers;
using Martec.Domain.Models;
using Martec.Infrastructure.Service;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using Martec.Infrastruture.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Martec.Web.Controllers
{

    public class OrderController : Controller
    {
        private CartService _cart;
        private OrderManager _order;
        private UserManager _user;

        // GET: Order
        public OrderController(CartService cart, OrderManager order, UserManager user)
        {
            _cart = cart;
            _order = order;
            _user = user;
            //var repo = new OrderRepository(new MartecEntities());
            //var order = new OrderManager(repo);
            //_order = order;
            //var cart = new CartService();
            //_cart = cart;
            //var repos = new UserRepository(new MartecEntities());
            //_user = new UserManager(repos, new MD5Encryption(), new EmailNotification());
        }

        public ActionResult Place(OrderModel model)
        {
            return View(model);
        }
        [HttpPost]
        public ActionResult Place(FormCollection collection)
        {
            try
            {

                //Getting Items From the Cart
                var items = _cart.GetCartItems().ToArray();

                //Get UserId
                var userId = User.Identity.GetUserId<int>();

                // Place Order with userId and items
                var order = _order.PlaceOrder(userId, items);

                ////send Email Notifications To the Admins
                // _user.SendEmailToAdmin();

                TempData["OrderId"] = order.OrderId;
                TempData["Order"] = order;

                return RedirectToAction("Delivery", "DeliveryDetails");

               // return View(order);

            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                ModelState.AddModelError("Error", ex);

                return Redirect(Request.UrlReferrer.ToString());
            }


        }
    }
}