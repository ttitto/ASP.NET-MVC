[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TtitterMvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TtitterMvc.App_Start.NinjectWebCommon), "Stop")]

namespace TtitterMvc.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ttitter.Data.Data;
    using Microsoft.AspNet.Identity;
    using Ttitter.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TtitterMvc.Infrastructure.Services.Contracts;
    using TtitterMvc.Infrastructure.Services.Profiles;
    using TtitterMvc.Infrastructure.Services.Account;
    using TtitterMvc.Infrastructure.Services.Base;
    using TtitterMvc.Infrastructure.Services.Home;
    using TtitterMvc.Infrastructure.Services.Tteets;
    using TtitterMvc.Infrastructure.Services.Images;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITtitterData>().To<TtitterData>().WithConstructorArgument("context", new TtitterDbContext());
            kernel.Bind<IUserStore<User>>().To<UserStore<User>>().WithConstructorArgument("context", new TtitterDbContext());
            kernel.Bind<IBaseService>().To<BaseService>().WithConstructorArgument("data", new TtitterData(new TtitterDbContext()));
            kernel.Bind<IHomeService>().To<HomeService>().WithConstructorArgument("data", new TtitterData(new TtitterDbContext()));
            kernel.Bind<IProfileService>().To<ProfilesService>().WithConstructorArgument("data", new TtitterData(new TtitterDbContext()));
            kernel.Bind<ITteetService>().To<TteetsService>().WithConstructorArgument("data", new TtitterData(new TtitterDbContext()));
            kernel.Bind<IAccountService>().To<AccountService>().WithConstructorArgument("data", new TtitterData(new TtitterDbContext()));
            kernel.Bind<IImageService>().To<ImagesService>().WithConstructorArgument("data", new TtitterData(new TtitterDbContext()));

            //kernel.Bind<IUserProvider>().To<AspNetUserProvider>();
            // TODO: Add here more ninject bindings
        }
    }
}
