namespace Order.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Order.Models.OrderingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // 3shan aseer aswe run bdun el shasheh ele aktub feha migraions w update
            AutomaticMigrationDataLossAllowed = true;// 3shan ra7 y36ene error enu fe data ra7 n5srha ana b7kelu ok ana bt7ml el ms2olyeh

            ContextKey = "Order.Models.OrderingContext";
        }

        protected override void Seed(Order.Models.OrderingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


        }
    }
}
