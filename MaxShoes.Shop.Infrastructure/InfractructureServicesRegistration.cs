using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MaxShoes.Shop.Application.Contracts.Infrastructure;
using MaxShoes.Shop.Infrastructure.Email;
using System;
using System.Net.Http.Headers;
using System.Text;
using MaxShoes.Shop.Infrastructure.FileServices;

namespace MaxShoes.Shop.Infrastructure
{
    public static class InfractructureServicesRegistration
    {
        public static IServiceCollection AddInfractructureServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {

            MailConfigSection mailConfigSection = configuration.GetSection("mailConfigSection").Get<MailConfigSection>();
            services.AddSingleton(mailConfigSection);

            services.AddHttpClient<IEmailService, MailgunEmailService>(cfg =>
            {
                cfg.BaseAddress = new Uri("https://api.mailgun.net/");
                cfg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{mailConfigSection.MailgunKey}")));
            });

            services.AddTransient<IFileService, FileService>();
            return services;
        }
    }
}
