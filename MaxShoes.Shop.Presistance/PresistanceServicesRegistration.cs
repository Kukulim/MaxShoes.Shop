using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Presistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Presistance
{
    public static class PresistanceServicesRegistration
    {
        public static IServiceCollection AddPresistanceServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MaxDb")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}
