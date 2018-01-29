using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual Employee Employee { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
