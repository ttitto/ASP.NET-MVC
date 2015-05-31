namespace TtitterMvc.Infrastructure.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TtitterMvc.ViewModels.Profiles;


    public interface IProfileService : IBaseService
    {
        IEnumerable<ProfileViewModel> GetUserProfiles();

        int? GetUserActiveProfile();
    }
}
