namespace TtitterMvc.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;

    using Ttitter.Data.Models;
    using TtitterMvc.ViewModels.Tteets;

    public interface ITteetService : IBaseService
    {
        IEnumerable<Tteet> GetPagedPublicTteets(int tteetsPageSize, int page);
    }
}
