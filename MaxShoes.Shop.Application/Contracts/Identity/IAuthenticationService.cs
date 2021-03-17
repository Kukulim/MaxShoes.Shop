using MaxShoes.Shop.Application.Models.AccountModels;
using MaxShoes.Shop.Identity.Models.AccountModels;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<LoginResult> AuthenticateAsync(LoginRequest request);
        Task RegisterAsync(RegisterRequest request);
        Task LogoutAsync(string currentUsetEmail);
        Task EditContactAsync(EditContactRequest request);
        Task RemoveAccoutAsync(RemoveAccountRequest request);
    }
}
