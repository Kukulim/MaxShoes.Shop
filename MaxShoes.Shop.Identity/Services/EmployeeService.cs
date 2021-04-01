using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Application.Models.UserModels;
using MaxShoes.Shop.Identity.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Identity.Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly ApplicationIdentityDbContext context;

        public EmployeeService(ApplicationIdentityDbContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> GetAllEmployeesAsync()
        {
            var test = await context.Users.Where(n => n.Role == UserRoles.Employee).ToListAsync();

            return test;
        }
    }
}
