namespace TtitterMvc.Infrastructure.Services.Contracts
{
    using Ttitter.Data.Data;

    public interface IBaseService
    {
        ITtitterData Data { get; }
    }
}
