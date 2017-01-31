namespace GigHub.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Attendance
    {
        [Key]
        [Column(Order = 1)]
        public int GigId { get; set; }
        public Gig Gig { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
        public Artist Attendee { get; set; }
    }
}