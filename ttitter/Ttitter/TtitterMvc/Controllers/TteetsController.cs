namespace TtitterMvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Ttitter.Data.Data;

    public class TteetsController : BaseController
    {
        public TteetsController(ITtitterData ttitterData)
            :base(ttitterData)
        {
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