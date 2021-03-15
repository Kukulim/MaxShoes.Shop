using MaxShoes.Shop.Application.Contracts.Identity;
using MaxShoes.Shop.Identity.JwtAuth;
using MaxShoes.Shop.Identity.Services;
using MaxshoesBack.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace MaxShoes.Shop.Identity
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            JwtAuth.JwtTokenConfig jwtTokenConfig = configuration.GetSection("jwtTokenConfig").Get<JwtAuth.JwtTokenConfig>(); ;
            services.AddSingleton(jwtTokenConfig);

            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MaxDb"),
                    b => b.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName)));


            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.RequireHttpsMetadata = false;
            //        o.SaveToken = false;
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            ValidIssuer = configuration["JwtSettings:Issuer"],
            //            ValidAudience = configuration["JwtSettings:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //        };

            //        o.Events = new JwtBearerEvents()
            //        {
            //            OnAuthenticationFailed = c =>
            //            {
            //                c.NoResult();
            //                c.Response.StatusCode = 500;
            //                c.Response.ContentType = "text/plain";
            //                return c.Response.WriteAsync(c.Exception.ToString());
            //            },
            //            OnChallenge = context =>
            //            {
            //                context.HandleResponse();
            //                context.Response.StatusCode = 401;
            //                context.Response.ContentType = "application/json";
            //                var result = JsonConvert.SerializeObject("401 Not authorized");
            //                return context.Response.WriteAsync(result);
            //            },
            //            OnForbidden = context =>
            //            {
            //                context.Response.StatusCode = 403;
            //                context.Response.ContentType = "application/json";
            //                var result = JsonConvert.SerializeObject("403 Not authorized");
            //                return context.Response.WriteAsync(result);
            //            },
            //        };
            //    });
            return services;
        }
    }
    
}
