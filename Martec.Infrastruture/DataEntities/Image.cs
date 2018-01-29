﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string URL { get; set; }

        public virtual Product Product { get; set; }
    }
}
