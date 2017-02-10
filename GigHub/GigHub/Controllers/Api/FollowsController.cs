namespace GigHub.Controllers.Api
{
    using System.Linq;
    using System.Web.Http;
    using Dtos;
    using Microsoft.AspNet.Identity;
    using Models;

    [Authorize]
    public class FollowsController : ApiController
    {
        private ApplicationDbContext context;

        public FollowsController()
        {
            this.context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowDto follow)
        {
            var userId = User.Identity.GetUserId();
            if (this.context.Follows.Any(f => f.FollowedId == follow.FollowedId && f.FollowerId == userId))
            {
                return this.BadRequest("The current user already follows this artist.");
            }

            var followToCreate = new Follow()
            {
                FollowedId = follow.FollowedId,
                FollowerId = userId
            };
            this.context.Follows.Add(followToCreate);
            this.context.SaveChanges();

            return this.Ok();
        }
    }
}
