namespace TtitterMvc.Controllers
{
    using System.Web.Mvc;

    using TtitterMvc.Infrastructure.Services.Contracts;

    public abstract class BaseController : Controller
    {
        IBaseService baseService;

        public BaseController(IBaseService baseService)
        {
            this.baseService = baseService;
        }
    }
}