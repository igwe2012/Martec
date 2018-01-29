using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Models
{
    public class ItemModel : Model
    {
        [Key]
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity{ get; set; }
        public string Size { get; set; }
        public DateTime CreatedDate { get; set; }


        public virtual ProductModel Product { get; set; } = new ProductModel { };
    }
}
