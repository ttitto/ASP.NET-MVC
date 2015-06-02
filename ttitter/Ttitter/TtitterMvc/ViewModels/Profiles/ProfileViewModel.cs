namespace TtitterMvc.ViewModels.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Ttitter.Data.Models;
    using TtitterMvc.Infrastructure.Mapping;

    public class ProfileViewModel : IMapFrom<Profile>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Visibility { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public string TimeZoneId { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Profile, ProfileViewModel>()
                .ForMember(m => m.Country, opt => opt.MapFrom(pvm => pvm.Country.ToString()))
                .ForMember(m => m.Status, opt => opt.MapFrom(pvm => pvm.Status.ToString()))
                .ForMember(m => m.Visibility, opt => opt.MapFrom(pvm => pvm.Visibility.ToString()))
                .ForMember(m => m.Language, opt => opt.MapFrom(pvm => pvm.Language.ToString()))
                .ReverseMap();

        }
    }
}