using Martec.Domain.Interfaces;
using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Models;
using Martec.Infrastruture.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Martec.Infrastruture.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }
        public ProductModel[] GetProducts()
        {

            var query = from product in _context.Set<Product>()
                        select new
                        {
                            Product = product,
                            Image = product.Images,
                            Categories = product.Category
                        };
            var records = query.ToArray();
            var data = from record in records
                       select new ProductModel
                       {
                           ProductId = record.Product.ProductId,
                           ProductName = record.Product.ProductName,
                           Size = record.Product.Size,
                           UnitPrice = record.Product.UnitPrice,
                           Image = record.Product.Image,
                           CreatedDate = record.Product.CreatedDate,
                           CategoryId = record.Product.CategoryId,
                           Images = (from img in record.Image
                                     select new ImageModel
                                     {
                                         ImageId = img.ImageId,
                                         ProductId = img.ProductId,
                                         URL = img.URL
                                     }).ToArray(),
                           Category = /*from cat in record.Categories
                                      select*/ new CategoryModel
                                               {
                                                   CategoryId = record.Categories.CategoryId,
                                                   CategoryName = record.Categories.CategoryName,
                                                   CreatedDate = record.Categories.CreatedDate


                                               }


                       };
            return data.ToArray();
        }
        public ProductModel[] GetProducts(int Id)
        {
            var query = from product in _context.Set<Product>()
                        where product.CategoryId == Id
                        select new
                        {
                            Product = product,
                            Image = product.Images,
                            Categories = product.Category
                        };
            var records = query.ToArray();
            var data = from record in records
                       select new ProductModel
                       {
                           ProductId = record.Product.ProductId,
                           ProductName = record.Product.ProductName,
                           Size = record.Product.Size,
                           UnitPrice = record.Product.UnitPrice,
                           Image = record.Product.Image,
                           CreatedDate = record.Product.CreatedDate,
                           CategoryId = record.Product.CategoryId,
                           Images = (from img in record.Image
                                     select new ImageModel
                                     {
                                         ImageId = img.ImageId,
                                         ProductId = img.ProductId,
                                         URL = img.URL
                                     }).ToArray(),
                           Category = /*from cat in record.Categories
                                      select*/ new CategoryModel
                                               {
                                                   CategoryId = record.Categories.CategoryId,
                                                   CategoryName = record.Categories.CategoryName,
                                                   CreatedDate = record.Categories.CreatedDate,
                                               }
                       };
            return data.ToArray();
        }
        public ProductModel GetProductsById(int ProductId)
        {


            var query = from product in _context.Set<Product>()
                        where product.ProductId == ProductId
                        select new
                        {
                            Product = product,
                            //Image = product.Images,
                            //Categories = product.Category
                        };
            var records = query.FirstOrDefault();
            var data = new ProductModel
            {
                ProductId = records.Product.ProductId,
                ProductName = records.Product.ProductName,
                Size = records.Product.Size,
                UnitPrice = records.Product.UnitPrice,
                Image = records.Product.Image,
                CreatedDate = records.Product.CreatedDate,
                CategoryId = records.Product.CategoryId,
                // Images = (from img in records.Image
                //           select new ImageModel
                //           {
                //               ImageId = img.ImageId,
                //               ProductId = img.ProductId,
                //               URL = img.URL
                //           }).ToArray(),
                // Category = /*from cat in record.Categories
                //select*/ new CategoryModel
                //         {
                //             CategoryId = records.Categories.CategoryId,
                //             CategoryName = records.Categories.CategoryName,
                //             CreatedDate = records.Categories.CreatedDate,
                //         }

            };
            return data;

        }
       
        public ProductModel AddProduct(ProductModel model, string ImgUrl)
        {

            var product = new Product
            {
                ProductName = model.ProductName,
                CreatedDate = model.CreatedDate,
                Size = model.Size,
                UnitPrice = model.UnitPrice,
                Image = model.Image,
                CategoryId = model.CategoryId

            };
            if (product.ProductName == null && product.Size == null)
            {
                _context.Set<Product>().Add(product);
                _context.SaveChanges();
                model.ProductId = product.ProductId;
            }
            else
            {
                throw new Exception("Product already exist");
            }


            return model;
        }

        public void EditProduct(ProductModel model, string ImgUrl)
        {
            var product = new Product
            {
                ProductId = model.ProductId,
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                Size = model.Size,
                UnitPrice = model.UnitPrice,
                CreatedDate = model.CreatedDate,
                Image = ImgUrl

            };
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var productId = _context.Set<Product>().Find(id);
            if (productId != null)
            {
                var delete = _context.Entry(productId).State = EntityState.Deleted;
                _context.Set<Product>().Remove(productId);
                _context.SaveChanges();
            }

        }
    }
}
