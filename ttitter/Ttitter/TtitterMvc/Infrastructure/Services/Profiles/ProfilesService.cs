namespace TtitterMvc.Infrastructure.Services.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;

    using TtitterMvc.Infrastructure.Services.Base;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.ViewModels.Profiles;
    using Ttitter.Data.Data;

    public class ProfilesService : BaseService, IProfileService
    {
        public ProfilesService(ITtitterData ttitterData)
            : base(ttitterData)
        {
        }

        public IEnumerable<ProfileViewModel> GetUserProfiles()
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var profiles = this.Data.Profiles.All()
                .Where(p => p.User.Id == currentUserId)
                .Project()
                .To<ProfileViewModel>()
                .ToList();

            return profiles;
        }


        public int? GetUserActiveProfile()
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            int? activeProfileId = this.Data.Users.All()
                .Where(u => u.Id == currentUserId)
                .Select(u => u.SelectedProfileId)
                .FirstOrDefault();

            return activeProfileId;
        }
    }
}