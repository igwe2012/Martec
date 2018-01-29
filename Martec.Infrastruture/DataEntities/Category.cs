using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        private DateTime? createdDate;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }


        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
