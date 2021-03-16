using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Identity.Models.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaxshoesBack.Services.UserServices
{
    public interface IUserServices
    {
        Task<bool> IsAnExistingUserAsync (string userName, string UserEmail);

        Task<User> GetUserByEmailAsync (string userEmail);

    }
}