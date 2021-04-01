using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Identity.Models.AccountModels;
using MaxShoes.Shop.Identity.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Identity
{
    public interface IUserServices
    {
        Task<bool> IsAnExistingUserAsync(string userName, string UserEmail);

        Task<User> GetUserByEmailAsync(string userEmail);
        Task CreateAsync(User newUser);
        Task EditContactsAsync(User currentUser);
        Task DeleteAsync(User currentUser);
        Task<User> GetUserAsync(string id);
        Task EditAsync(User currentUser);
    }
}