namespace Ttitter.Data.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<Profile> profiles;

        public User()
            : base()
        {
            this.profiles = new HashSet<Profile>();
        }

        public Country Country { get; set; }

        public Language Language { get; set; }

        public string TimeZoneId { get; set; }

        public virtual ICollection<Profile> Profiles
        {
            get { return this.profiles; }
            set { this.profiles = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
