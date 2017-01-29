namespace GigHub.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using ViewModels;

    public class GigsController : Controller
    {
        private readonly ApplicationDbContext context;

        public GigsController()
        {
            this.context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = this.context.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}