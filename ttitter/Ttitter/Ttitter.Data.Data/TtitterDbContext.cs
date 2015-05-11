namespace Ttitter.Data.Data
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Ttitter.Data.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class TtitterDbContext : IdentityDbContext<User>
    {
        public TtitterDbContext()
            : base("TtitterConn", throwIfV1Schema: false)
        {
        }


        public IDbSet<Profile> Profiles { get; set; }

        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public static TtitterDbContext Create()
        {
            return new TtitterDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.SenderProfile)
                .WithMany(s => s.SentMessages)
                .WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
