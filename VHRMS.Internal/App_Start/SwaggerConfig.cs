using System.Web.Http;
using WebActivatorEx;
using VHRMS.Internal;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace VHRMS.Internal
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
               
                        c.SingleApiVersion("v1", "VHRMS.Internal");

                       
                    })
                .EnableSwaggerUi(c =>
                    {
                       
                    });
        }
    }
}
