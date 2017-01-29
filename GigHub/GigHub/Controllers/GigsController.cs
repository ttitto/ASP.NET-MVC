namespace GigHub.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models;
    using ViewModels;

    public class GigsController : Controller
    {
        private readonly ApplicationDbContext context;

        public GigsController()
        {
            this.context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = this.context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var gig = new Gig()
                {
                    ArtistId = User.Identity.GetUserId(),
                    DateTime = viewModel.GetDateTime(),
                    GenreId = viewModel.Genre,
                    Venue = viewModel.Venue
                };
                this.context.Gigs.Add(gig);
                this.context.SaveChanges();

                return this.RedirectToAction("Index", "Home");
            }

            viewModel.Genres = this.context.Genres.ToList();
            return this.View(viewModel);
        }
    }
}