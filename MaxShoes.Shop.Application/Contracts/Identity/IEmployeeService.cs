using MaxShoes.Shop.Application.Features.Employees.Commands.CreateEmployee;
using MaxShoes.Shop.Identity.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Presistance
{
    public interface IEmployeeService
    {
        Task<List<User>> GetAllEmployeesAsync();
        Task<string> AddAsync(User request);
        Task UpdateAsync(User employee);
    }
}
