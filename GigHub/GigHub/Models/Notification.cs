namespace GigHub.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        protected Notification() { }
        private Notification(NotificationType type, Gig gig)
        {
            if (null == gig)
            {
                throw new ArgumentNullException("gig");
            }

            this.Type = type;
            this.Gig = gig;
            this.DateTime = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }
        [Required]
        public Gig Gig { get; private set; }

        public static Notification GigCreated(Gig gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        }

        public static Notification GigUpdated(Gig newGig, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(NotificationType.GigUpdated, newGig);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;
            return notification;
        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(NotificationType.GigCanceled, gig);
        }
    }
}