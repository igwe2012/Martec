using Martec.Domain.Interfaces;
using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Managers
{
    public class CategoryManager
    {
        private ICategoryRepository _categoryRepo;

        public CategoryManager(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public CategoryModel[] GetAllCategories()
        {
            return _categoryRepo.AllCategory();
        }
        public CategoryModel GetAllCategories(int Id)
        {
            return _categoryRepo.AllCategory(Id);
        }
        public CategoryModel CreateCategory(CategoryModel model)
        {
            //check if category exit
            var category = _categoryRepo.GetCategory(model.CategoryName);
            if (category != null) throw new Exception("Category already exist");

            model.Validate();

            //Create category
          return  _categoryRepo.CreateCategory(model);

           
        }

        public void UpdateCategory(CategoryModel model)
        {
            //update category name

            _categoryRepo.EditCategory(model);
        }

        public void DeleteCategory(int id)
        {
            //delete category record
               _categoryRepo.RemoveItem(id);

        }

       
    }
}
