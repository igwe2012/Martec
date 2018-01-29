﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public  string ReceiptNo { get; set; }
        public DateTime PaymentDate { get; set; }

        public virtual Order Order { get; set; }
    }
}
