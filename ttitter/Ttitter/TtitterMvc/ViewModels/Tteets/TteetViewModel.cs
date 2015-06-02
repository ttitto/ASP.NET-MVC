namespace TtitterMvc.ViewModels.Tteets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using AutoMapper;

    using Ttitter.Data.Models;
    using TtitterMvc.Infrastructure.Mapping;

    public class TteetViewModel : IMapFrom<Tteet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Profile { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public int? ImageId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tteet, TteetViewModel>()
                .ForMember(tvm => tvm.Profile, opt => opt.MapFrom(t => t.Profile.Name))
                .ReverseMap();
        }
    }
}