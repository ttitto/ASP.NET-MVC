namespace GigHub.Dtos
{
    using Mapping;
    using Models;

    public class ArtistDto : IMapFrom<Artist>, IMapTo<Artist>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}