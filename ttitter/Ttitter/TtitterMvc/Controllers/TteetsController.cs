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

        [Authorize]
        public ActionResult Retteet(int hostId)
        {
            return new EmptyResult();
        }

        [Authorize]
        public ActionResult Reply(int tteetId)
        {
            return new EmptyResult();
        }

        [Authorize]
        public ActionResult Report(int tteetId)
        {
            return new EmptyResult();
        }

        [Authorize]
        public ActionResult ToggleFavourite(int tteetId)
        {
            return new EmptyResult();
        }

        [Authorize]
        public ActionResult FbShare(int tteetId)
        {
            return new EmptyResult();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(TteetInputModel tteet)
        //{

        //}
    }
}