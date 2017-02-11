namespace GigHub.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Gig
    {
        public Gig()
        {
            this.Attendances = new Collection<Attendance>();
        }

        public int Id { get; set; }
        public bool IsCanceled { get; private set; }
        public bool IsUpdated { get; private set; }
        [Required]
        public string ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(255)]
        public string Venue { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Attendance> Attendances { get; private set; }

        public void Cancel()
        {
            this.IsCanceled = true;
            var notification = new Notification(NotificationType.GigCanceled, this);

            foreach (var attendee in this.Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Update()
        {
            this.IsUpdated = true;
            var notification = new Notification(NotificationType.GigUpdated, this);
            notification.OriginalDateTime = this.DateTime;
            notification.OriginalVenue = this.Venue;
            foreach (var attendee in this.Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }
    }
}