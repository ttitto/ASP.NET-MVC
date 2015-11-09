using Microsoft.AspNet.Identity.EntityFramework;
using MvcUoWAutomNin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcUoWAutomNin.Data
{
    public class MvcUoWAutomNinDbContext : IdentityDbContext<User>
    {
        public MvcUoWAutomNinDbContext()
            : base("MvcUoWAutomNinConnection", throwIfV1Schema: false)
        {
        }

        // TODO: Place IDbSet<> below
        // public IDbSet<Image> Images { get; set; 

        public static MvcUoWAutomNinDbContext Create()
        {
            return new MvcUoWAutomNinDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
