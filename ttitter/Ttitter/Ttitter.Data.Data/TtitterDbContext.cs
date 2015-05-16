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

        public IDbSet<Tteet> Tteets { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<Image> Images { get; set; }

        public static TtitterDbContext Create()
        {
            return new TtitterDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Message>()
            //    .HasRequired(m => m.SenderProfile)
            //    .WithMany(s => s.SentMessages)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Tteet>()
            //    .HasOptional(t => t.Image)
            //    .WithMany(i => i.Tteets)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Profile>()
            //    .HasOptional(p => p.Image)
            //    .WithMany(i => i.Profiles)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Profile>()
                .HasMany<Tteet>(p => p.FavouriteTteets)
                .WithMany(t => t.FavourizingProfiles)
                .Map(pt =>
                {
                    pt.MapLeftKey("ProfileId");
                    pt.MapRightKey("FavouriteTteetId");
                    pt.ToTable("ProfilesFavouriteTteets");
                });

            modelBuilder.Entity<Profile>()
                .HasMany<Tteet>(p => p.RetteetedTteets)
                .WithMany(t => t.RetteetingProfiles)
                .Map(pt =>
                {
                    pt.MapLeftKey("ProfileId");
                    pt.MapRightKey("RetteetedTteetId");
                    pt.ToTable("ProfilesRetteetedTteets");
                });

            modelBuilder.Entity<Profile>()
                .HasMany<Tteet>(p => p.ReportedTteets)
                .WithMany(t => t.ReportingProfiles)
                .Map(pt =>
                {
                    pt.MapLeftKey("ProfileId");
                    pt.MapRightKey("ReportedTteetId");
                    pt.ToTable("ProfilesReportedTteets");
                });

            modelBuilder.Entity<Profile>()
                .HasMany<Tteet>(p => p.FbSharedTteets)
                .WithMany(t => t.FbSharingProfiles)
                .Map(pt =>
                {
                    pt.MapLeftKey("ProfileId");
                    pt.MapRightKey("FbSharedTteetId");
                    pt.ToTable("ProfilesFbSharedTteets");
                });
        }
    }
}
