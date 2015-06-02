namespace TtitterMvc.Infrastructure.Services.Tteets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Ttitter.Data.Data;
    using Ttitter.Data.Models;
    using TtitterMvc.Infrastructure.Services.Base;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.ViewModels.Tteets;

    public class TteetsService : BaseService, ITteetService
    {
        public TteetsService(ITtitterData ttitterData)
            : base(ttitterData)
        {
        }

        public IEnumerable<Tteet> GetPagedPublicTteets(int tteetsPageSize, int page)
        {
            var pagedPublicTteets = this.Data.Tteets
                 .All()
                 .OrderByDescending(t => t.CreatedOn)
                 .Skip(tteetsPageSize * page - 1)
                 .Take(tteetsPageSize);

            return pagedPublicTteets;
        }
    }
}