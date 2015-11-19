using MvcUoWAutomNin.Data;
using MvcUoWAutomNin.MVC.Notifications;
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

        public BaseController(IMvcUoWAutomNinData mvcUoWAutomNinData)
        {
            this.mvcUoWAutomNinData = mvcUoWAutomNinData;
        }

        public IMvcUoWAutomNinData MvcUoWAutomNinData
        {
            get { return this.mvcUoWAutomNinData; }
            set { this.mvcUoWAutomNinData = value; }
        }


        [NonAction]
        protected virtual void AddNotification(string message, NotificationType notificationType)
        {
            if (!this.TempData.ContainsKey(notificationType.ToString()))
            {
                this.TempData.Add(notificationType.ToString(), new HashSet<string>());
            }

            var notifications = this.TempData[notificationType.ToString()] as ICollection<string>;
            notifications.Add(message);
        }
    }
}