namespace GigHub.Dtos
{
    using Mapping;
    using Models;

    public class AttendanceDto : IMapFrom<Attendance>, IMapTo<Attendance>
    {
        public int GigId { get; set; }
    }
}