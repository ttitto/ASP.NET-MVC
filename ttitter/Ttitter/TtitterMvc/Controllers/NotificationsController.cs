namespace TtitterMvc.Controllers
{
    using System.Web.Mvc;
    using TtitterMvc.Infrastructure.Services.Contracts;

    public class NotificationsController : BaseController
    {
        INotificationService notificationService;

        public NotificationsController(IBaseService baseService, INotificationService notificationService)
            : base(baseService)
        {
            this.notificationService = notificationService;
        }

        // GET: Notifications
        public ActionResult Index()
        {
            return View();
        }
    }
}