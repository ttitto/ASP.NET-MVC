namespace TtitterMvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Ttitter.Data.Data;
    using TtitterMvc.Infrastructure.Services.Contracts;

    public class TteetsController : BaseController
    {
        private ITteetService tteetService;

        public TteetsController(IBaseService baseService, ITteetService tteetService)
            : base(baseService)
        {
            this.tteetService = tteetService;
        }

        // GET: Tteets
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(TteetInputModel tteet)
        //{

        //}
    }
}