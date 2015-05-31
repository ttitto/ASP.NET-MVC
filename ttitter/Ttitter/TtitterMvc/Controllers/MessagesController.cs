namespace TtitterMvc.Controllers
{
    using System.Web.Mvc;
    using TtitterMvc.Infrastructure.Services.Contracts;

    public class MessagesController : BaseController
    {
        IMessageService messageService;

        public MessagesController(IBaseService baseService, IMessageService messageService)
            : base(baseService)
        {
            this.messageService = messageService;
        }

        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }
    }
}