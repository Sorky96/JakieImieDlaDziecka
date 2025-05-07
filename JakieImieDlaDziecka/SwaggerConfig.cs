using Swashbuckle.Application;
using System.Web.Http;

namespace JakieImieDlaDziecka
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Names API");
                })
                .EnableSwaggerUi();
        }
    }
}
