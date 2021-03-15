using MaxShoes.Shop.Identity.Models.UserModels;
using MaxshoesBack.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Identity.Services
{
    class UserServices : IUserServices
    {
        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAnExistingUserAsync(string userName, string UserEmail)
        {
            throw new NotImplementedException();
        }
    }
}
