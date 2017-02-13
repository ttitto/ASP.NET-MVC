namespace GigHub.Dtos
{
    using System;
    using Mapping;
    using Models;

    public class NotificationDto : IMapFrom<Notification>, IMapTo<Notification>
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public GigDto Gig { get; set; }

    }
}