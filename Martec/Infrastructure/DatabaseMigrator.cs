//using Martec.Infrastruture.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Martec.Infrastructure
{
    public class DatabaseMigrator
    {
        public static void UpdateDatabase()
        {
            try
            {
                //var migrator = new DbMigrator(new Infrastruture.Migrations.Configuration());
                //migrator.Update();
            }
            catch (Exception ex)
            {

            }

        }
    }
}