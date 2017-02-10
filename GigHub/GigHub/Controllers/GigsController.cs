namespace GigHub.Controllers
{
    using System;
    using System.Data.Entity;
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
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = this.context.Gigs
                .Where(g => g.ArtistId == userId && g.DateTime > DateTime.Now && g.IsCanceled == false)
                .Include(g => g.Genre)
                .ToList();

            return this.View(gigs);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = this.context
                .Attendances.Where(att => att.AttendeeId == userId)
                .Select(att => att.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            var viewModel = new GigsViewModel()
            {
                UpcommingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm attending"
            };

            return this.View("Gigs", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = this.context.Genres.ToList(),
                Heading = "Add a Gig"
            };

            return View("GigForm", viewModel);
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

                return this.RedirectToAction("Mine", "Gigs");
            }

            viewModel.Genres = this.context.Genres.ToList();
            return this.RedirectToAction("GigForm", "Gigs");
        }

        [Authorize]
        public ActionResult Edit(int gigId)
        {
            var userId = User.Identity.GetUserId();
            var gig = this.context.Gigs.Single(g => g.Id == gigId && g.ArtistId == userId);
            var viewModel = new GigFormViewModel()
            {
                Genres = this.context.Genres.ToList(),
                Id = gig.Id,
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue,
                Heading = "Edit a Gig"
            };

            return View("GigForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var gig = this.context.Gigs.Single(g => g.Id == viewModel.Id && g.ArtistId == userId);
                gig.Venue = viewModel.Venue;
                gig.DateTime = viewModel.GetDateTime();
                gig.GenreId = viewModel.Genre;

                this.context.SaveChanges();

                return this.RedirectToAction("Mine", "Gigs");
            }

            viewModel.Genres = this.context.Genres.ToList();
            return this.View("GigForm", "Gigs");
        }
    }
}