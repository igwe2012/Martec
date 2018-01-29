using Martec.Domain.Interfaces;
using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Martec.Domain.Managers
{
    public class ProductManager
    {
        private IProductRepository _productRepo;

        public ProductManager(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public ProductModel[] GetInventory()
        {
            return _productRepo.GetProducts();

        }
        public ProductModel[] GetInventory(int Id)
        {
            return _productRepo.GetProducts(Id);

        }

        public ProductModel GetProduct(int ProductId)
        {
            return _productRepo.GetProductsById(ProductId);
        }

        public ProductModel CreateProduct(ProductModel model,string ImgUrl)
        {
            

            // Create Product
            return _productRepo.AddProduct(model,ImgUrl);
        }

        public void UpdateProduct(ProductModel model,string ImgUrl)
        {
            //update category name

            _productRepo.EditProduct(model,ImgUrl);
        }

        public void RemoveProduct(int id)
        {
            //Check to see if the Id is null
            var product =  _productRepo.GetProductsById(id);
            if (product == null) throw new Exception("The product does not exist");

            //Delete the product
            _productRepo.DeleteProduct(id);
         }
    }
}
