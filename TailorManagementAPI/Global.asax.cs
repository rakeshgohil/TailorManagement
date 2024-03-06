using System.Web.Http;
using TailorManagementDB;
using TailorManagementModels;
using Unity;
using Unity.WebApi;

namespace TailorManagementAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var container = new UnityContainer();

            // Register IRepository and ShirtRepository
            container.RegisterType<IRepository<Shirt>, ShirtRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
