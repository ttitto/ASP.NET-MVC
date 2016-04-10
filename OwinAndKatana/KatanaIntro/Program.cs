using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(KatanaIntro.Startup))]
namespace KatanaIntro
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Microsoft.Owin.Hosting;
    using Owin;

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        string uri = "http://localhost:8080";

    //        using (WebApp.Start<Startup>(uri))
    //        {
    //            Console.WriteLine("Started!");
    //            Console.ReadKey();
    //            Console.WriteLine("Stopped!");
    //        }
    //    }
    //}

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // app.UseErrorPage();
            // app.UseWelcomePage();
            //app.Run(ctx =>
            //{
            //    return ctx.Response.WriteAsync("Hello World!");
            //});

            app.Use(async (ctx, next) =>
            {
                Console.WriteLine($"Requesting: {ctx.Request.Path}");
                await next();
            });

            //app.Use(async (ctx, next) =>
            //{
            //    foreach (var pair in ctx.Environment)
            //    {
            //        Console.WriteLine($"{pair.Key}: {pair.Value}");
            //    }

            //    await next();
            //});

            ConfigureWebApi(app);

            app.Use<HelloWorldComponent>();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultRoute",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }

    public class HelloWorldComponent
    {
        private Func<IDictionary<string, object>, Task> next;

        public HelloWorldComponent(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            if (null != response)
            {
                using (var writer = new StreamWriter(response))
                {
                    await writer.WriteAsync("Hello!!");

                }
            }
            await next(environment);
        }
    }
}
