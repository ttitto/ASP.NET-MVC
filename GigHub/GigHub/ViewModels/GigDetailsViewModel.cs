namespace GigHub.ViewModels
{
    using System;
    using AutoMapper;
    using Mapping;
    using Models;

    public class GigDetailsViewModel : IMapFrom<Gig>, IHaveCustomMappings
    {
        public string Heading { get; set; }
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Venue { get; set; }
        public DateTime DateTime { get; set; }
        public bool Following { get; set; }
        public bool Going { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Gig, GigDetailsViewModel>()
                .ForMember(gvm => gvm.ArtistName, opt => opt.MapFrom(g => g.Artist.Name))
                .ReverseMap();
        }
    }
}