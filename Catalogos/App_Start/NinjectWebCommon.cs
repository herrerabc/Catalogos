using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Logica;
using System;
using System.Web;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SIGST.PlanesWebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SIGST.PlanesWebUI.App_Start.NinjectWebCommon), "Stop")]
namespace SIGST.PlanesWebUI.App_Start
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));
            kernel.Bind<Logica.Interfaces.ICatalogos>().To<LUsuarios>().Named("LUsuarios");
            kernel.Bind<Logica.Interfaces.ICatalogos>().To<LUsuarioRoles>().Named("LUsuarioRoles");
            kernel.Bind<Logica.Interfaces.ICatalogos>().To<LRoles>().Named("LRoles");
        }
    }
}