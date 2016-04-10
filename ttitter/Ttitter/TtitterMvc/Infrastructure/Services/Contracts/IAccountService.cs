namespace TtitterMvc.Infrastructure.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Ttitter.Data.Models;

    public interface IAccountService :IBaseService
    {
        User GetCurrentApplicationUser();

        void SetActiveProfileToUser(int profileId);
    }
}