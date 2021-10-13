using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolService.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigCores(this IServiceCollection service)
        {
            service.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });
            });

        }

        public static void ConfigIISIntegration(this IServiceCollection service)
        {
            service.Configure<IISOptions>(opts => { });
        }

        public static void ConfigRepository(this IServiceCollection service)
        {
            service.AddTransient<UnitOfWork<ApplicationContext>>();
        }


    }
}