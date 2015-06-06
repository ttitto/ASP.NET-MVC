namespace TtitterMvc.ViewModels.Images
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Ttitter.Data.Models;
    using TtitterMvc.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string MimeType { get; set; }

        public string FileExtension { get; set; }
    }
}