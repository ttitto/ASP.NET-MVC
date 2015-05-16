namespace TtitterMvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Ttitter.Data.Data;

    public abstract class BaseController : Controller
    {
        ITtitterData ttitterData;

        public BaseController(ITtitterData ttitterData)
        {
            this.ttitterData = ttitterData;
        }

        protected ITtitterData TtitterData
        {
            get { return this.ttitterData; }
        }

    }
}