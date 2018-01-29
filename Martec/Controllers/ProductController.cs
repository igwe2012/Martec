using Martec.Domain.Managers;
using Martec.Domain.Models;
using Martec.Infrastructure.Service;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using Martec.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Martec.Web.Controllers
{
    public class ProductController : Controller
    {
        private CartService _cart;
        private ProductManager _product;

        public ProductController(ProductManager product, CartService cart)
        {
            _cart = cart;
            _product = product;
            //var repo = new ProductRepository(new MartecEntities());
            //_product = new ProductManager(repo);
            //_cart = new CartService();
        }
        // GET: Product
        public ActionResult Index()
        {
            var product = _product.GetInventory().ToArray();

            return View(product);
        }
        public ActionResult List(int Id)
        {
            Session["Url"] = Request.Url.ToString();
            ViewBag.GetId = Id;

            var Model = new ProductViewModel
            {
                Product = _product.GetInventory(Id),

                Cart = _cart.GetCartItems()
            };


            return View(Model);
        }
    }
}