namespace RedirectHttpModule.Controllers
{
    using System.Web.Mvc;
    using Extensions;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return JsonNet(ViewBag.Message);
            //return View();
        }

        private ActionResult JsonNet(object data)
        {
            return new JsonNetResult() { Data = data };
        }
    }
}