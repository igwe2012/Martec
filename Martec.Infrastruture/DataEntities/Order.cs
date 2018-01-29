using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
         //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        private DateTime? createdDate;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.Now; }
            set { createdDate = value; }
        }
        //public DateTime? CreatedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDelivery> OrderDeliveries { get; set; } = new HashSet<OrderDelivery>();
        public virtual ICollection<Item> Items { get; set; } = new HashSet<Item>();
        public virtual ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
   
    
}
