using MaxShoes.Shop.Application.Contracts.Identity;
using MaxShoes.Shop.Application.Models.AccountModels;
using MaxShoes.Shop.Identity.Models.AccountModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Application.Contracts.Identity.IAuthenticationService _authenticationService;
        public AccountController(Application.Contracts.Identity.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<LoginResult>> AuthenticateAsync(LoginRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterRequest request)
        {
            await _authenticationService.RegisterAsync(request);
            return Ok();
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            var CurrentUsetEmail = User.FindFirst(ClaimTypes.Email).Value;
            await _authenticationService.LogoutAsync(CurrentUsetEmail);
            return Ok();
        }

        [HttpPost("editcontact")]
        [Authorize]
        public async Task<ActionResult> EditContact([FromBody] EditContactRequest request)
        {
            await _authenticationService.EditContactAsync(request);
            return Ok();
        }

        [HttpDelete("remove")]
        [Authorize]
        public async Task<ActionResult> Remove([FromBody] RemoveAccountRequest request)
        {
            await _authenticationService.RemoveAccoutAsync(request);
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var userName = User.Identity.Name;
            var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
            _authenticationService.RefreshToken(request, userName, accessToken);
            return Ok();
        }

        [Authorize]
        [HttpPost("sendConfirmEmail")]
        public async Task<ActionResult> SendConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            await _authenticationService.SendConfirmEmailAsync(request);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult> ConfirmEmailTokenAsync([FromBody] ConfirmEmailTokenRequest request)
        {
            await _authenticationService.ConfirmEmailTokenAsync(request);
            return Ok();
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request)
        {
            await _authenticationService.ChangePasswordAsync(request);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("SendPasswordResetEmail")]
        public async Task<ActionResult> SendPasswordResetEmail([FromBody] PasswordResetEmailRequest request)
        {
            await _authenticationService.SendPasswordResetEmailAsync(request);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("PasswordReset")]
        public async Task<ActionResult> PasswordReset(PasswordResetRequest request)
        {
            await _authenticationService.PasswordResetAsync(request);
            return Ok();
        }
    }
}
