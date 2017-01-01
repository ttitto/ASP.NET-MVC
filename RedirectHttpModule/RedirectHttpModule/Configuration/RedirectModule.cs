namespace RedirectHttpModule.Configuration
{
    using System;
    using System.Web;
    using System.Web.Configuration;

    public class RedirectModule : IHttpModule
    {
        private static readonly string RedirectSectionName = "redirects";
        private HttpApplication context;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            this.context = context;
            context.MapRequestHandler += RedirectUrls;
        }

        public void RedirectUrls(object sender, EventArgs e)
        {
            RedirectSection section = WebConfigurationManager.GetWebApplicationSection(RedirectSectionName) as RedirectSection;

            if (null != section)
            {
                foreach (Redirect redirect in section.Redirects)
                {
                    if (redirect.Old == this.context.Request.RawUrl)
                    {
                        this.context.Response.Redirect(redirect.New);
                        break;
                    }
                }
            }
        }
    }
}