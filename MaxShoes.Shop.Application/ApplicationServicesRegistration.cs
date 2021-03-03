using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MaxShoes.Shop.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;

        }
    }
}
