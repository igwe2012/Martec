using Martec.Domain.Interfaces;
using Martec.Domain.Interfaces.Repositories;
using Martec.Domain.Interfaces.Utility;
using Martec.Infrastruture.DataEntities;
using Martec.Infrastruture.Repositories;
using Martec.Infrastruture.Utilities;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Martec.Infrastructure.Modules
{
    public class MainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IEncryption>().To<MD5Encryption>();
           // Bind<IEmailNotification>().To<EmailNotification>();
            Bind<DbContext>().To<MartecEntities>().InRequestScope();
        }
    }
}