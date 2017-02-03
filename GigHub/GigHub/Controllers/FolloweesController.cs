namespace GigHub.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models;

    public class FolloweesController : Controller
    {
        private ApplicationDbContext context;

        public FolloweesController()
        {
            this.context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = this.context.Follows
                .Where(follow => follow.FollowerId == userId)
                .Select(follow => follow.Followed)
                .ToList();

            return View(artists);
        }
    }
}