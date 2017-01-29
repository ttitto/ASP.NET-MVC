namespace GigHub.Controllers
{
    using System;
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
            var gig = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse($"{viewModel.Date} {viewModel.Time}"),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            this.context.Gigs.Add(gig);
            this.context.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}