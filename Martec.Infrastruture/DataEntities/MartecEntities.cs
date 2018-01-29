using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martec.Infrastruture.DataEntities
{
    public class MartecEntities : DbContext
    {

        //public MartecEntities() : base("name=MartecEntities")
        //{
        //    // the terrible hack
        //    var ensureDLLIsCopied =
        //            System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        //}
        public virtual DbSet<Category> Categories { get; set; }
        //  public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDelivery> OrderDeliveries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

       // public System.Data.Entity.DbSet<Martec.Domain.Models.CategoryModel> CategoryModels { get; set; }

       // public System.Data.Entity.DbSet<Martec.Domain.Models.ProductModel> ProductModels { get; set; }

        //public System.Data.Entity.DbSet<Martec.Domain.Models.OrderDeliveryModel> OrderDeliveryModels { get; set; }
        //public System.Data.Entity.DbSet<Martec.Domain.Models.CategoryModel> CategoryModels { get; set; }

        //public System.Data.Entity.DbSet<Martec.Domain.Models.ProductModel> ProductModels { get; set; }


    }
}
