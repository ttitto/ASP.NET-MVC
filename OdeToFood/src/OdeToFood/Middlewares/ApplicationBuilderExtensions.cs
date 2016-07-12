namespace Microsoft.AspNetCore.Builder
{
    using System.IO;
    using Hosting;
    using Microsoft.Extensions.FileProviders;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, IHostingEnvironment env)
        {
            var root = Path.Combine(env.ContentRootPath, "node_modules");
            var provider = new PhysicalFileProvider(root);
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;
            app.UseStaticFiles(options);
            return app;
        }
    }
}
