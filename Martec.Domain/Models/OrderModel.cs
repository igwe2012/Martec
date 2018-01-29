using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Models
{
    public class OrderModel 
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<ItemModel> Items { get; set; } = new HashSet<ItemModel>();
    }
}
