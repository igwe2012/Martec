using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Domain.Models
{
    public class OrderDeliveryModel 
    {
        [Key]
        public int OrderDeliveryId { get; set; }
        public int OrderId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required,DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public virtual OrderModel Order { get; set; }
    }
}
