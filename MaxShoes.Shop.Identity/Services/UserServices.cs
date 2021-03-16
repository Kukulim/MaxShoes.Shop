using MaxShoes.Shop.Identity.Models.UserModels;
using MaxshoesBack.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Identity.Services
{
    class UserServices : IUserServices
    {
        private readonly ApplicationIdentityDbContext context;

        public UserServices(ApplicationIdentityDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUserByEmailAsync(string userEmail)
        {
            return await context.Users.Where(u=>u.Email==userEmail).FirstOrDefaultAsync();
        }

        public Task<bool> IsAnExistingUserAsync(string userName, string UserEmail)
        {
            throw new NotImplementedException();
        }
    }
}
