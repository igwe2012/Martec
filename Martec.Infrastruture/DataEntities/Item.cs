using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class Item
    {

        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public string PRoductName { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
