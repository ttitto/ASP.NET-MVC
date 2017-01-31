using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Models;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            this.context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingGigs = this.context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now);

            return View(upcomingGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}