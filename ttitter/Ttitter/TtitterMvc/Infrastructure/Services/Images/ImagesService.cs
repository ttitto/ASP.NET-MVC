namespace TtitterMvc.Infrastructure.Services.Images
{
    using Ttitter.Common.MimeMappings;
    using Ttitter.Data.Data;
    using TtitterMvc.Infrastructure.Services.Base;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.ViewModels.Images;

    public class ImagesService : BaseService, IImageService
    {
        public ImagesService(ITtitterData ttitterData)
            : base(ttitterData)
        {
        }

        public ImageViewModel ById(int id)
        {
            ImageViewModel profileViewImage = null;

            var profileImage = this.Data.Images.Find(id);

            if (null != profileImage)
            {
                if (MimeTypeMap.IsFileTypeAllowed(profileImage.FileExtension, this.AllowedImageMimeTypes))
                {
                    profileViewImage = AutoMapper.Mapper.Map<ImageViewModel>(profileImage);
                    profileViewImage.MimeType = MimeTypeMap.GetMimeType(profileImage.FileExtension);
                }
            }

            return profileViewImage;
        }
    }
}