namespace MvcUoWAutomNin.MVC.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public static class NotificationsExtensions
    {
        public static IEnumerable<String> GetNotifications(this HtmlHelper htmlHelper, NotificationType notificationType)
        {
            IEnumerable<string> notifications = null;
            if (htmlHelper.ViewContext.Controller.TempData.ContainsKey(notificationType.ToString()))
            {
                notifications = htmlHelper.ViewContext.Controller.TempData[notificationType.ToString()] as IEnumerable<string>;
            }

            return notifications;
        }
    }
}
