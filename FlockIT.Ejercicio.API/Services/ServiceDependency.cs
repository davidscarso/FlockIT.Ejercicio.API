using FlockIT.Ejercicio.API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlockIT.Ejercicio.API.Services
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar los servicios
            services.AddTransient<IDataGeoService, DataGeoService>();
            services.AddTransient<ILoginService, LoginService>();

            return services;
        }
    }
}
