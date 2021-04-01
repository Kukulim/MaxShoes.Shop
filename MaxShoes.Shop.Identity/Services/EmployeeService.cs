using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Application.Models.UserModels;
using MaxShoes.Shop.Identity.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MaxShoes.Shop.Identity.Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly ApplicationIdentityDbContext context;

        public EmployeeService(ApplicationIdentityDbContext context)
        {
            this.context = context;
        }

        public async Task<string> AddAsync(User request)
        {
            request.Id = Guid.NewGuid().ToString();
            request.Contact.Id = Guid.NewGuid().ToString();
            request.Contact.UserId = request.Id;
            request.Password = BC.HashPassword(request.Password);
            await context.AddAsync(request);
            await context.SaveChangesAsync();
            return request.Id;
        }

        public async Task<List<User>> GetAllEmployeesAsync()
        {
            var test = await context.Users.Where(n => n.Role == UserRoles.Employee).ToListAsync();

            return test;
        }
    }
}
