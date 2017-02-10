namespace GigHub.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public Artist User { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }

        public bool IsRead { get; set; }
    }
}