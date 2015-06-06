namespace TtitterMvc.Infrastructure.Services.Contracts
{
    using TtitterMvc.ViewModels.Images;

    public interface IImageService
    {
        ImageViewModel ById(int id);
    }
}
