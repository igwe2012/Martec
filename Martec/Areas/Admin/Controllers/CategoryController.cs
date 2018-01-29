using Martec.Domain.Managers;
using Martec.Domain.Models;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Martec.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager _category;

        public CategoryController()
        {
            var Repo = new CategoryRepository(new MartecEntities());
            _category = new CategoryManager(Repo);

        }
        // GET: Category
        public ActionResult Index()
        {
            var category = _category.GetAllCategories();
            return View(category);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _category.CreateCategory(model);
                    return RedirectToAction("Index", "Category", new { Area = "Admin" });
                }

            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                ModelState.AddModelError("Error", ex);

            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var category = _category.GetAllCategories(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Edit(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _category.UpdateCategory(model);
                    return RedirectToAction("Index", "Category", new { Area = "Admin" });
                }


            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                ModelState.AddModelError("error", ex);
            }


            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                _category.DeleteCategory(id);
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex);
            }
            return View();
        }
    }
}