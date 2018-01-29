using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public decimal UnitPrice { get; set; }
        public string Image { get; set; }
        private DateTime? createdDate;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        public virtual Category Category { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
