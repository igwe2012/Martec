using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class Employee
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
       
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual User User { get; set; }
    }
}
