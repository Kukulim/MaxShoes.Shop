using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Presistance.Repositories;
using MaxShoes.Shop.Presistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaxShoes.Shop.Presistance
{
    public static class PresistanceServicesRegistration
    {
        public static IServiceCollection AddPresistanceServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MaxDb")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
