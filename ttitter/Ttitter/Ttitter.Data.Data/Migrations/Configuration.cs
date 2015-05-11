namespace Ttitter.Data.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ttitter.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TtitterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(TtitterDbContext context)
        {
            User pesho = new User();
            pesho.Id = Guid.NewGuid().ToString();
            pesho.UserName = "pesho";
            pesho.Country = Country.Bulgaria;
            pesho.Email = "pesho@pesho.com";
            

            context.Users.AddOrUpdate(pesho);
            context.SaveChanges();
        }
    }
}
