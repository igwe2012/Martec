using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        CategoryModel[] AllCategory();
      
        CategoryModel CreateCategory(CategoryModel model);
        CategoryModel GetCategory(string categoryName);
        void EditCategory(CategoryModel model);
        CategoryModel AllCategory(int id);
        void RemoveItem(int id);
    }
}
