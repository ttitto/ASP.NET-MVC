namespace RedirectHttpModule.Extensions
{
    using System.Web.Mvc;

    public class ThemeViewEngine : RazorViewEngine
    {
        public ThemeViewEngine()
        {
            this.ViewLocationFormats = new string[] { "~/Theme/{1}/{0}.cshtml" };
            this.PartialViewLocationFormats = new string[] { "~/Theme/{1}/{0}.cshtml" };
        }
    }
}