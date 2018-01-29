using Martec.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Martec.Web.Models
{
    public class ProductViewModel
    {
        public ProductModel[] Product { get; set; } = new ProductModel[] { };
        public List<ItemModel> Cart { get; set; } = new List<ItemModel> { };
    }
}