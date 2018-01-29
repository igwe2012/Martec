using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Martec.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        ProductModel[] GetProducts();
        ProductModel[] GetProducts(int Id);
        ProductModel GetProductsById(int id);
        //ProductModel GetProductsByName(ProductModel model);
        ProductModel AddProduct(ProductModel model,string ImgUrl);
        void EditProduct(ProductModel model,string ImgUrl);
        void DeleteProduct(int id);
    }
}
