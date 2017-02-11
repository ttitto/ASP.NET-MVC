namespace GigHub.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {

        protected Notification() { }
        public Notification(NotificationType type, Gig gig)
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
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        [Required]
        public Gig Gig { get; private set; }
    }
}