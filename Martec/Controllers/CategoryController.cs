using Martec.Domain.Managers;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Martec.Web.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryManager _category;

        public CategoryController(CategoryManager category)
        {
            //var Repo = new CategoryRepository(new MartecEntities());
            //_category = new CategoryManager(Repo);
            _category = category;
        }
        // GET: Category
        public ActionResult Index()
        {


            var category = _category.GetAllCategories();
            return View(category);
        }
    }
}