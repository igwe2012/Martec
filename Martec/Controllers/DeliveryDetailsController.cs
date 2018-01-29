using Martec.Domain.Managers;
using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Martec.Controllers
{
    public class DeliveryDetailsController : Controller
    {
        private OrderManager _order;

        public DeliveryDetailsController(OrderManager order)
        {
            _order = order;
        }
        // GET: DeliveryDetails
        [HttpGet]
        public ActionResult Delivery()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Delivery(OrderDeliveryModel model)
        {
            try
            {
                
                //Getting The OrderId
                var orderId = Convert.ToInt32(TempData["OrderId"]);

                //Storing the model to the database
                  _order.CreateDeliveryInfo(model, orderId);

                //redirecting to order controller
                return RedirectToAction("Place", "Order", TempData["Order"] as OrderModel);
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