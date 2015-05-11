namespace Ttitter.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Guid ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        [Required]
        public NotificationCase NotificationCase { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        public DateTime ViewedOn { get; set; }
    }
}
