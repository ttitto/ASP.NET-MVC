namespace GigHub.Controllers.Api
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;
    using Dtos;
    using Mapping;
    using Microsoft.AspNet.Identity;
    using Models;

    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            this.context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = this.context.UserNotifications
                .Where(un => un.UserId == userId && un.IsRead == false)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();


            return notifications.To<NotificationDto>();
        }
    }
}
