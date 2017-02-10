namespace GigHub.Controllers.Api
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Models;

    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext context;

        public GigsController()
        {
            this.context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = this.context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
            if (gig.IsCanceled)
            {
                return this.NotFound();
            }

            gig.IsCanceled = true;
            this.context.SaveChanges();

            var notification = new Notification()
            {
                DateTime = DateTime.Now,
                Gig = gig,
                Type = NotificationType.GigCanceled
            };

            var attendees = this.context.Attendances
                .Where(att => att.GigId == gig.Id)
                .Select(a => a.Attendee)
                .ToList();

            foreach (var attendee in attendees)
            {
                var userNotification = new UserNotification()
                {
                    User = attendee,
                    Notification = notification
                };
                this.context.UserNotifications.Add(userNotification);
            }

            this.context.SaveChanges();
            return this.Ok();
        }
    }
}
