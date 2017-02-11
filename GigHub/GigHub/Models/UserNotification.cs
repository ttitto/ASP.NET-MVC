namespace GigHub.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserNotification
    {
        protected UserNotification() { }

        public UserNotification(Artist user, Notification notification)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            if (notification == null)
            {
                throw new ArgumentNullException("notification");
            }

            this.Notification = notification;
            this.User = user;
        }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public Artist User { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }
        public Notification Notification { get; private set; }

        public bool IsRead { get; set; }
    }
}