using MaxShoes.Shop.Identity.Models.UserModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Contracts.Presistance
{
    public interface IEmployeeService
    {
        Task<List<User>> GetAllEmployeesAsync();
    }
}
