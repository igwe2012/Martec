using Martec.Domain.Managers;
using Martec.Infrastructure.Service;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using Martec.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Martec.Web.Controllers
{
    public class CartController : Controller
    {
        private ProductManager _product;
        private CartService _cart;
        private CategoryManager _category;

        public CartController(CategoryManager category, ProductManager product, CartService cart)
        {
            //var Repo = new CategoryRepository(new MartecEntities());
            //_category = new CategoryManager(Repo);

            //var repo = new ProductRepository(new MartecEntities());
            //_product = new ProductManager(repo);
            //_cart = new CartService
            _category = category;
            _product = product;
            _cart = cart;
        }
        // GET: Cart
        public ActionResult Index()
        {

            return View();
        }
        public void Error(string message)
        {
            TempData["Message"] = message;

        }
        public void Notification(string message)
        {
            TempData["Notification"] = message;

        }

        [Authorize]
        public ActionResult ShowCart()
        {
            try
            {

                //  var Model = new ProductViewModel
                // {

                // Product = _product.GetInventory(Id),
                //Cart = _cart.GetCartItems();
               var cart =  _cart.GetCartItems();

                // };



                return View(cart);
            }
            catch (Exception ex)

            {
                Error(ex.Message);
            }

            return View();
        }

        
        public ActionResult Add(int Id)
        {
            try
            {
                
                var product = _product.GetProduct(Id);
                _cart.AddToCart(product);
            }
            catch (Exception ex)

            {
                Error(ex.Message);
            }
            Notification("Item Added To Cart");
            
            return Redirect(Request.UrlReferrer.ToString());
            //return RedirectToAction("ShowCart", "Cart");
           // return View();
            // return RedirectToAction("List", new RouteValueDictionary(
            //new { controller = "Product", action = "List", Id = Id }));
            // return RedirectToAction("List", "Product",new { id = 99 });
        }
        public ActionResult Update(FormCollection Form)
        {


            //try
            //{
            int productId = int.Parse(Form["ProductId"]);
            int quantity = int.Parse(Form["Quantity"]);
            // var product = _product.GetProduct(Id);
            _cart.UpdateCart(productId, quantity);
            return Redirect(Request.UrlReferrer.ToString());
            // return RedirectToAction("ShowCart", "Cart");
            //}
            //catch (Exception ex)
            //{
            //    Error(ex.Message);
            //}


        }
        public ActionResult Remove(int Id)
        {

            try
            {

                _cart.RemoveCart(Id);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }


            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());

        }
        [ChildActionOnly]
        public ActionResult Button()
        {
            var cart =_cart.GetCartItems();
            return PartialView(cart);
        }
    }
}