namespace GigHub.Dtos
{
    using System;
    using Mapping;
    using Models;

    public class GigDto : IMapFrom<Gig>, IMapTo<Gig>
    {
        public int Id { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsUpdated { get; set; }
        public ArtistDto Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public GenreDto Genre { get; set; }
    }
}