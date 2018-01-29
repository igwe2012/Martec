using Martec.Domain.Interfaces;
using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Models;
using Martec.Infrastruture.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DbContext _db;

        public CategoryRepository(DbContext context)
        {
            _db = context;
        }
        public CategoryModel[] AllCategory()
        {
            var query = from category in _db.Set<Category>()
                        select new
                        {
                            Category = category,
                           // Product = category.Products
                        };
            var records = query.ToArray();
            var data = from record in records
                       select new CategoryModel
                       {
                           CategoryId = record.Category.CategoryId,
                           CategoryName = record.Category.CategoryName,
                           CreatedDate = record.Category.CreatedDate,
                           //Products = (from product in record.Product
                           //            select new ProductModel
                           //            {
                           //                ProductId = product.ProductId,
                           //                ProductName = product.ProductName,
                           //                CategoryId = product.CategoryId,
                           //                UnitPrice = product.UnitPrice,
                           //                Size = product.Size
                                          
                           //            }).ToArray()
                       };
            return data.ToArray();
        }
        public CategoryModel AllCategory(int categoryId)
        {
            var query = from category in _db.Set<Category>()
                        where category.CategoryId == categoryId
                        select new
                        {
                            Category = category,
                            Product = category.Products
                        };
            var records = query.FirstOrDefault();
            var data =  new CategoryModel
                       {
                           CategoryId = records.Category.CategoryId,
                           CategoryName = records.Category.CategoryName,
                           CreatedDate = records.Category.CreatedDate,
                           Products = (from product in records.Product
                                       select new ProductModel
                                       {
                                           ProductId = product.ProductId,
                                           ProductName = product.ProductName,
                                           CategoryId = product.CategoryId,
                                           UnitPrice = product.UnitPrice,
                                           Size = product.Size
                                       }).ToArray()
                       };
            return data;
        }
        public CategoryModel CreateCategory(CategoryModel model)
        { 
            var categories = new Category
            {
                CategoryName = model.CategoryName,
                CreatedDate = DateTime.Now
            };
            _db.Set<Category>().Add(categories);
            _db.SaveChanges();
            model.CategoryId = categories.CategoryId;
            return model;
        }
        public void EditCategory(CategoryModel model)
        {
            var category = new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                CreatedDate = model.CreatedDate
            };
            _db.Entry(category).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public CategoryModel GetCategory(string categoryName)
        {
            var query = from category in _db.Set<Category>()
                        where category.CategoryName == categoryName
                        select new
                        {
                            category,
                            

                        };
            var records = query.FirstOrDefault();

            var transform =  new CategoryModel
                            {
                                CategoryName = records.category.CategoryName,
                                CategoryId = records.category.CategoryId,
                                CreatedDate = records.category.CreatedDate,
                                
                            };
            return transform;


        }

        public void RemoveItem(int id)
        {
           var categoryId = _db.Set<Category>().Find(id);
            if(categoryId != null)
            {
               var delete =  _db.Entry(categoryId).State = EntityState.Deleted;
                _db.Set<Category>().Remove(categoryId);
                _db.SaveChanges();
            }

            
        }
    }
}
