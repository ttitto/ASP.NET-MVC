namespace TtitterMvc.Infrastructure.Services.Home
{
    using Ttitter.Data.Data;
    using TtitterMvc.Infrastructure.Services.Base;
    using TtitterMvc.Infrastructure.Services.Contracts;

    public class HomeService : BaseService, IHomeService
    {
        public HomeService(ITtitterData ttitterData)
            : base(ttitterData)
        {
        }
    }
}