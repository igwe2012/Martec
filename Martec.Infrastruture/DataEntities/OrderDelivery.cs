using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class OrderDelivery
    {
        public int OrderDeliveryId { get; set; }
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string DeliveryAddress { get; set; }
      
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
