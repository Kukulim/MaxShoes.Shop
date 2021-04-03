using MaxShoes.Shop.Application.Models.UserModels;
using MediatR;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Employees.Commands.EditEmployee
{
    public class EditEmployeeCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public Contact Contact { get; set; }
    }
}
