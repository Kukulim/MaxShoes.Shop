using MaxShoes.Shop.Application.Contracts.Identity;
using MaxShoes.Shop.Application.Contracts.Infrastructure;
using MaxShoes.Shop.Application.Models.AccountModels;
using MaxShoes.Shop.Application.Models.UserModels;
using MaxShoes.Shop.Identity.Models.AccountModels;
using MaxShoes.Shop.Identity.Models.UserModels;
using MaxshoesBack.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        private readonly ILogger<AuthenticationService> logger;

        public AuthenticationService(IJwtAuthManager jwtAuthManager, IEmailService emailSender, IConfiguration configuration, IUserServices userServices, ILogger<AuthenticationService> logger)
        {
            this.jwtAuthManager = jwtAuthManager;
            this.emailSender = emailSender;
            this.configuration = configuration;
            this.userServices = userServices;
            this.logger = logger;
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

            logger.LogInformation($"User [{request.Email}] logged in the system.");

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
            });
        }

        public async Task RegisterAsync(RegisterRequest request)
        {

            if (! await userServices.IsAnExistingUserAsync(request.UserName, request.Email))
            {
                var newUser = new User
                {
                    UserName = request.UserName,
                    Password = BC.HashPassword(request.Password),
                    Email = request.Email,
                    Contact = new Contact { Id = Guid.NewGuid().ToString() }
                };
                await userServices.CreateAsync(newUser);

                logger.LogInformation($"New user [{request.Email}] register.");

                var claims = new[]
{
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Email, request.Email)
            };
                var ConfirmToken = jwtAuthManager.GenerateConfirmEmailToken(request.UserName, claims, DateTime.Now);

                string Url = $"{configuration["appUrl"]}/api/account/confirmemail?UserName={request.UserName}&token={ConfirmToken}";

                await emailSender.SendEmailAsync(request.Email, "Confirm Email - Maxshoes", "<h1>Hello from Max Shoes</h1>" + $"<p> please confirm email by <a href='{Url}'>Click here!</a></p>");

            }

            else
            {
                throw new Exception($"Email {request.Email } already exists.");
            }
        }

        public Task LogoutAsync(string userEmail)
        {
            jwtAuthManager.RemoveRefreshTokenByUserEmail(userEmail);
            logger.LogInformation($"User [{userEmail}] logged out the system.");
            return Task.CompletedTask;
        }

        public async Task EditContactAsync(EditContactRequest request)
        {
            var CurrentUser = await userServices.GetUserByEmailAsync(request.Email);

            if (CurrentUser == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }
            CurrentUser.Contact = request.Contact;
            await userServices.EditContactsAsync(CurrentUser);
        }

        public async Task RemoveAccoutAsync(RemoveAccountRequest request)
        {
            var CurrentUser = await userServices.GetUserByEmailAsync(request.Email);
            if (CurrentUser == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }
            if (CurrentUser.Email == request.Email && CurrentUser.UserName == request.UserName && BC.Verify(request.Password, CurrentUser.Password))
            {
                await userServices.DeleteAsync(CurrentUser);
                logger.LogInformation($"User [{request.Email}] removed.");
            }
            else
            {
                throw new Exception($"Credentials for '{request.UserName} aren't valid'.");
            }

        }

        public LoginResult RefreshToken(RefreshTokenRequest request, string userName, string token)
        {
            try
            {
                logger.LogInformation($"User [{userName}] is trying to refresh JWT token.");
                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    throw new Exception($"User unauthorized");
                }

                var jwtResult = jwtAuthManager.Refresh(request.RefreshToken, token, DateTime.Now);
                logger.LogInformation($"User [{userName}] has refreshed JWT token.");
                return (new LoginResult
                {
                    UserName = userName,
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException)
            {
                throw new Exception($"User unauthorized");
            }
        }

        public async Task SendConfirmEmailAsync(ConfirmEmailRequest request)
        {
            var claims = new[]
{
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Email, request.UserEmail)
            };
            var ConfirmToken = jwtAuthManager.GenerateConfirmEmailToken(request.UserName, claims, DateTime.Now);

            string Url = $"{configuration["appUrl"]}/api/account/confirmemail?UserName={request.UserName}&token={ConfirmToken}";

            await emailSender.SendEmailAsync(request.UserEmail, "Confirm Email - Maxshoes", "<h1>Hello from Max Shoes</h1>" + $"<p> please confirm email by <a href='{Url}'>Click here!</a></p>");
        }

        public async Task ConfirmEmailTokenAsync(ConfirmEmailTokenRequest request)
        {
            var AcceptedEmail = jwtAuthManager.ConfirmEmailToken(request.UserName, request.Token, DateTime.Now);
            if (AcceptedEmail == null)
            {
                throw new Exception($"User with {AcceptedEmail} not found.");
            }
            var CurrentUser = await userServices.GetUserByEmailAsync(AcceptedEmail);
            CurrentUser.IsEmailConfirmed = true;
            await userServices.EditAsync(CurrentUser);
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new Exception($"User with {request.Email} not found.");
            }
            var CurrentUser = await userServices.GetUserByEmailAsync(request.Email);
            if (BC.Verify(request.OldPassword, CurrentUser.Password))
            {
                CurrentUser.Password = BC.HashPassword(request.NewPassword);
                await userServices.EditAsync(CurrentUser);
                logger.LogInformation($"User [{request.Email}] change password.");
            }
            throw new Exception($"User unauthorized");
        }

        public async Task SendPasswordResetEmailAsync(PasswordResetEmailRequest request)
        {
            var claims = new[]
{
                new Claim(ClaimTypes.Email, request.Email)
            };
            var ConfirmToken = jwtAuthManager.GeneratePasswordResetToken(claims, DateTime.Now);

            string Url = $"{configuration["appUrl"]}/api/account/passwordreset?UserEmail={request.Email}&token={ConfirmToken}";

            await emailSender.SendEmailAsync(request.Email, "Reset Password - Maxshoes", "<h1>Hello from Max shoes</h1>" + $"<p> to reset your password: <a href='{Url}'>Click here!</a></p>");
        }

        public async Task PasswordResetAsync(PasswordResetRequest request)
        {
            var CurrentUser = await userServices.GetUserByEmailAsync(request.UserEmail);
            var AcceptedEmail = jwtAuthManager.ConfirmPasswordResetToken(request.UserEmail, request.Token);
            if (AcceptedEmail == null)
            {
                throw new Exception($"User with {request.UserEmail} not found.");
            }
            if (CurrentUser.Email == request.UserEmail)
            {
                CurrentUser.Password = jwtAuthManager.GenerateTemporaryPasswordString();
                await emailSender.SendEmailAsync(request.UserEmail, "Reset Password - Maxshoes", $"Your new temporary password: '{CurrentUser.Password}'");
                await userServices.EditAsync(CurrentUser);
            }
        }

    }
}
