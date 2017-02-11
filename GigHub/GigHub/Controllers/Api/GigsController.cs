namespace GigHub.Controllers.Api
{
    using System.Data.Entity;
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
            var gig = this.context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == userId);
            if (gig.IsCanceled)
            {
                return this.NotFound();
            }

            gig.Cancel();
            this.context.SaveChanges();
            return this.Ok();
        }
    }
}
