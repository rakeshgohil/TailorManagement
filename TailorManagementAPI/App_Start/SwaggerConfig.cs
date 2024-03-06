using System.Web.Http;
using WebActivatorEx;
using TailorManagementAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace TailorManagementAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "TailorManagementAPI");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }
    }
}
