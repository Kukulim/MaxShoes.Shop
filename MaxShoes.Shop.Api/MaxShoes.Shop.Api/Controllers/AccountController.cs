using MaxShoes.Shop.Application.Contracts.Identity;
using MaxShoes.Shop.Application.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet("test")]
        //public async Task<ActionResult<LoginResult>> Test(LoginRequest request)
        //{
        //    return Ok("test");
        //}
        //[HttpPost("register")]
        //public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        //{
        //    return Ok(await _authenticationService.RegisterAsync(request));
        //}
    }
}
