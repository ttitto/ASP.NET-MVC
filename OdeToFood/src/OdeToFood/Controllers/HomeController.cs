namespace OdeToFood.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return this.Content("Hello from Controller index action.");
        //}

        //public ObjectResult Index()
        //{
        //    var model = new Restaurant { Id = 1, Name = "Sabatino's"};

        //    // default return type is JSON
        //    return new ObjectResult(model);
        //}

        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Sabatino's" };

            // default return type is JSON
            return View(model);
        }
    }
}
