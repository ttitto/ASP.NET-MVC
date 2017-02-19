using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            this.context = new ApplicationDbContext();
        }

        public ActionResult Index(string searchTerm = null)
        {
            var upcomingGigs = this.context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now && g.IsCanceled == false);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                upcomingGigs = upcomingGigs.
                    Where(g => g.Artist.Name.Contains(searchTerm) ||
                    g.Genre.Name.Contains(searchTerm) ||
                    g.Venue.Contains(searchTerm));
            }

            var viewModel = new GigsViewModel()
            {
                UpcommingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcomming Gigs",
                SearchTerm = searchTerm
            };

            return View("Gigs", viewModel);
        }
    }
}