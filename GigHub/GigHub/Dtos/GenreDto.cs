namespace GigHub.Dtos
{
    using Mapping;
    using Models;

    public class GenreDto : IMapFrom<Genre>, IMapTo<Genre>
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}