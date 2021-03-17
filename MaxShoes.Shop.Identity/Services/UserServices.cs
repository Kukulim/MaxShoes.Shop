using MaxShoes.Shop.Identity.Models.AccountModels;
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

        public async Task CreateAsync(User newUser)
        {
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string userEmail)
        {
            return await context.Users.Where(u=>u.Email==userEmail).FirstOrDefaultAsync();
        }

        public async Task<bool> IsAnExistingUserAsync(string userName, string UserEmail)
        {
            var user = await context.Users.Where(user => user.UserName == userName || user.Email == UserEmail).FirstOrDefaultAsync();
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task EditContactsAsync(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User userToRemove)
        {

            context.Users.Remove(userToRemove);
            await context.SaveChangesAsync();
        }
    }
}
