using Martec.Domain.Managers;
using Martec.Domain.Models;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using Martec.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Martec.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager _product;
        private CategoryManager _category;

        public ProductController()
        {
            var repo = new ProductRepository(new MartecEntities());
            _product = new ProductManager(repo);
            var Repo = new CategoryRepository(new MartecEntities());
            _category = new CategoryManager(Repo);
        }
        // GET: Admin/Product
        public ActionResult Index(int Id)
        {
            var product = _product.GetInventory(Id);

            return View(product);
        }
        public ActionResult Create2()
        {
            ViewBag.CategoryId = new SelectList(_category.GetAllCategories(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create2(CreateProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //initialize the createdDate Properties
                    model.CreatedDate = DateTime.Now;
                    //Create product model
                    var product = new ProductModel()
                    {
                        ProductName = model.ProductName,
                        Size = model.Size,
                        CategoryId = model.CategoryId,
                        UnitPrice = model.UnitPrice,
                        CreatedDate = model.CreatedDate
                    };
                    //Upload Images
                    if (model.ImageUpload != null)
                    {
                        string name = Path.GetFileName(model.ImageUpload.FileName);
                        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images"), $"{ model.CategoryId}", model.ImageUpload.FileName);
                        string ImageUrl = Path.Combine(("~/Content/Images"), $"{ model.CategoryId}", model.ImageUpload.FileName);
                        model.ImageUpload.SaveAs(path);
                        product.Image = ImageUrl;

                        // Create the product
                        _product.CreateProduct(product, ImageUrl);
                        return RedirectToAction("index", "product", new { Area = "Admin", Id = model.CategoryId });
                    }

                    ModelState.AddModelError("Error", "No File Chosen");
                }
            }
            catch (Exception ex)
            {

                TempData["Message"] = ex.Message;
                ModelState.AddModelError("Error", ex);

            }
            ViewBag.CategoryId = new SelectList(_category.GetAllCategories(), "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var product = _product.GetProduct(id);
            var model = new CreateProductViewModel
            {
                CategoryId = product.CategoryId,
                Size = product.Size,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice
            };
            ViewBag.CategoryId = new SelectList(_category.GetAllCategories(), "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(CreateProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Creating Product Model
                    var product = new ProductModel()
                    {
                        ProductId = model.ProductId,
                        ProductName = model.ProductName,
                        Size = model.Size,
                        CategoryId = model.CategoryId,
                        UnitPrice = model.UnitPrice,
                        CreatedDate = model.CreatedDate

                    };
                    // Uploading the Images
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        string name = Path.GetFileName(model.ImageUpload.FileName);
                        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/Images"), $"{ model.CategoryId}", model.ImageUpload.FileName);
                        string ImageUrl = Path.Combine(("~/Content/Images"), $"{ model.CategoryId}", model.ImageUpload.FileName);
                        model.ImageUpload.SaveAs(path);
                        product.Image = ImageUrl;

                        //Updating The Product
                        _product.UpdateProduct(product, ImageUrl);
                        return RedirectToAction("index", "product", new { Area = "Admin", Id = model.CategoryId });
                    }

                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                ModelState.AddModelError("error", ex);
            }

            ViewBag.CategoryId = new SelectList(_category.GetAllCategories(), "CategoryId", "CategoryName", model.CategoryId);

            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                //Deleting the product
                _product.RemoveProduct(id);
                return RedirectToAction("Index", new { Area = "Admin" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex);
            }
            return View();
        }
    }

}
