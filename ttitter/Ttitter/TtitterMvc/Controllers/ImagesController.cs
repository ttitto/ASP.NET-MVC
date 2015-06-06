namespace TtitterMvc.Controllers
{
    using System.Web.Mvc;

    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.ViewModels.Images;

    public class ImagesController : BaseController
    {
        IImageService imageService;

        public ImagesController(IBaseService baseService, IImageService imageService)
            : base(baseService)
        {
            this.imageService = imageService;
        }

        public ActionResult ById(int id)
        {
            ImageViewModel profileImage = this.imageService.ById(id);
            if (null != profileImage)
            {
                return File(profileImage.Content, profileImage.MimeType);
            }

            return new EmptyResult();
        }
    }
}