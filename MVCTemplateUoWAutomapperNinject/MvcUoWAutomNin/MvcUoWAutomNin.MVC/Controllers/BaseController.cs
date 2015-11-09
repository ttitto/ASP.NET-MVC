using MvcUoWAutomNin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUoWAutomNin.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        IMvcUoWAutomNinData mvcUoWAutomNinData;

        public BaseController (IMvcUoWAutomNinData mvcUoWAutomNinData)
        {
            this.mvcUoWAutomNinData = mvcUoWAutomNinData;
        }
    }
}