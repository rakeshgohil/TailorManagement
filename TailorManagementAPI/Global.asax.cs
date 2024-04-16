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

            container.RegisterType<IRepository<Shirt>, ShirtRepository>();
            container.RegisterType<IRepository<Product>, ProductRepository>();
            container.RegisterType<IRepository<Customer>, CustomerRepository>();
            container.RegisterType<IRepository<Pant>, PantRepository>();
            container.RegisterType<IRepository<Bill>, BillRepository>();
            container.RegisterType<IRepository<ShirtConfiguration>, ShirtConfigurationRepository>();
            container.RegisterType<IRepository<PantConfiguration>, PantConfigurationRepository>();
            container.RegisterType<IRepository<BillPaymentDetail>, BillPaymentDetailRepository>();
            //container.RegisterType<IRepository<BillDetail>, BillDetailsRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
