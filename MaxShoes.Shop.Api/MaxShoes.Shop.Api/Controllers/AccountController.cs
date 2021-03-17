using MaxShoes.Shop.Application.Contracts.Identity;
using MaxShoes.Shop.Application.Models.AccountModels;
using MaxShoes.Shop.Identity.Models.AccountModels;
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
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
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

        [HttpPost("remove")]
        [Authorize]
        public ActionResult Remove([FromBody] RemoveAccountRequest request)
        {
            _authenticationService.RemoveAccoutAsync(request);
            return Ok();
        }
    }
}
