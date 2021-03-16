using MaxShoes.Shop.Application.Contracts.Identity;
using MaxShoes.Shop.Application.Contracts.Infrastructure;
using MaxShoes.Shop.Application.Models.AccountModels;
using MaxShoes.Shop.Application.Models.UserModels;
using MaxShoes.Shop.Identity.Models.AccountModels;
using MaxShoes.Shop.Identity.Models.UserModels;
using MaxshoesBack.Services.UserServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MaxShoes.Shop.Identity.Services
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtAuthManager jwtAuthManager;
        private readonly IEmailService emailSender;
        private readonly IConfiguration configuration;
        private readonly IUserServices userServices;

        public AuthenticationService(IJwtAuthManager jwtAuthManager, IEmailService emailSender, IConfiguration configuration, IUserServices userServices)
        {
            this.jwtAuthManager = jwtAuthManager;
            this.emailSender = emailSender;
            this.configuration = configuration;
            this.userServices = userServices;
        }
        public async Task<LoginResult> AuthenticateAsync(LoginRequest request)
        {

            var CurrentUser = await userServices.GetUserByEmailAsync(request.Email);

            if (CurrentUser == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            if (request.Email == configuration["ShopOwner:Email"] && request.Password == configuration["ShopOwner:Password"])
            {
                CurrentUser = new User
                {
                    Id = "maxshopowner",
                    Email = request.Email,
                    Password = BC.HashPassword(request.Password),
                    Role = UserRoles.MaxShopOwner,
                    UserName = "Max",
                    IsEmailConfirmed = true
                };
            }

            if (!BC.Verify(request.Password, CurrentUser.Password))
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, CurrentUser.UserName),
                new Claim(ClaimTypes.Email, CurrentUser.Email),
                new Claim(ClaimTypes.Role, CurrentUser.Role)
            };

            var jwtResult = jwtAuthManager.GenerateTokens(CurrentUser.UserName, claims, DateTime.Now);
            return (new LoginResult
            {
                UserId = CurrentUser.Id,
                Role = CurrentUser.Role,
                UserName = CurrentUser.UserName,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString,
                Email = CurrentUser.Email,
                IsEmailConfirmed = CurrentUser.IsEmailConfirmed,
                Contact = CurrentUser.Contact,
                //Notifications = CurrentUser.Notifications
            });
        }

        public Task RegisterAsync(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
