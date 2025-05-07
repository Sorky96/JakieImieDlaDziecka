using DataAccess;
using DataAccess.Interfaces;
using System;

namespace JakieImieDlaDziecka
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<INameRepository, NameRepository>();
             
            services.AddMemoryCache();
        }

    }
}
