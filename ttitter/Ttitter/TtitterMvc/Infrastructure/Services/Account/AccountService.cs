namespace TtitterMvc.Infrastructure.Services.Account
{
    using System.Web;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Ttitter.Data.Data;
    using Ttitter.Data.Models;
    using TtitterMvc.Infrastructure.Services.Base;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using System.Web.Mvc;
    using System.Net;
    using TtitterMvc.Infrastructure.ValidationErrors;

    public class AccountService : BaseService, IAccountService
    {
        public AccountService(ITtitterData ttitterData)
            : base(ttitterData)
        {
        }

        public User GetCurrentApplicationUser()
        {
            var principalId = HttpContext.Current.User.Identity.GetUserId();
            var user = this.Data.Users.Find(principalId);
            return user;
        }

        public void SetActiveProfileToUser(int profileId)
        {
            var currentUser = this.GetCurrentApplicationUser();

            if (!currentUser.Profiles.Any(p => p.Id == profileId))
            {
                throw new ValidationErrors(new GeneralError(string.Format("There is no Profile with Id {0} assigned to the current User.", profileId)));
            }

            currentUser.SelectedProfileId = profileId;

            this.Data.Users.Update(currentUser);
            this.Data.SaveChanges();

        }
    }
}