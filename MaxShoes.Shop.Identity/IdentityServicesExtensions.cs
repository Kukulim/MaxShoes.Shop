using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Identity
{
    public static class IdentityServicesExtensions
    {
        //    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        //    {

        //    var jwtTokenConfig = configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();
        //    services.AddSingleton(jwtTokenConfig);

        //    services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MaxDb"),
        //            b => b.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName)));



        //    services.AddIdentity<ApplicationUser, IdentityRole>()
        //            .AddEntityFrameworkStores<GloboTicketIdentityDbContext>().AddDefaultTokenProviders();

        //        services.AddTransient<IAuthenticationService, AuthenticationService>();

        //        services.AddAuthentication(options =>
        //        {
        //            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        })
        //            .AddJwtBearer(o =>
        //            {
        //                o.RequireHttpsMetadata = false;
        //                o.SaveToken = false;
        //                o.TokenValidationParameters = new TokenValidationParameters
        //                {
        //                    ValidateIssuerSigningKey = true,
        //                    ValidateIssuer = true,
        //                    ValidateAudience = true,
        //                    ValidateLifetime = true,
        //                    ClockSkew = TimeSpan.Zero,
        //                    ValidIssuer = configuration["JwtSettings:Issuer"],
        //                    ValidAudience = configuration["JwtSettings:Audience"],
        //                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        //                };

        //                o.Events = new JwtBearerEvents()
        //                {
        //                    OnAuthenticationFailed = c =>
        //                    {
        //                        c.NoResult();
        //                        c.Response.StatusCode = 500;
        //                        c.Response.ContentType = "text/plain";
        //                        return c.Response.WriteAsync(c.Exception.ToString());
        //                    },
        //                    OnChallenge = context =>
        //                    {
        //                        context.HandleResponse();
        //                        context.Response.StatusCode = 401;
        //                        context.Response.ContentType = "application/json";
        //                        var result = JsonConvert.SerializeObject("401 Not authorized");
        //                        return context.Response.WriteAsync(result);
        //                    },
        //                    OnForbidden = context =>
        //                    {
        //                        context.Response.StatusCode = 403;
        //                        context.Response.ContentType = "application/json";
        //                        var result = JsonConvert.SerializeObject("403 Not authorized");
        //                        return context.Response.WriteAsync(result);
        //                    },
        //                };
        //            });
        //    }
        }
    
}
