using MaxShoes.Shop.Identity.Models.UserModels;
using MaxshoesBack.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public User GetUserByEmailAsync(string userEmail)
        {
            return context.Users.Where(u=>u.Email==userEmail).FirstOrDefault();
        }

        public Task<bool> IsAnExistingUserAsync(string userName, string UserEmail)
        {
            throw new NotImplementedException();
        }
    }
}
