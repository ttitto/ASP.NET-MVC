namespace TtitterMvc.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;

    using TtitterMvc.ViewModels.Images;
    using TtitterMvc.ViewModels.Profiles;


    public interface IProfileService : IBaseService
    {
        IEnumerable<ProfileViewModel> GetUserProfiles();

        int? GetUserActiveProfile();
    }
}
