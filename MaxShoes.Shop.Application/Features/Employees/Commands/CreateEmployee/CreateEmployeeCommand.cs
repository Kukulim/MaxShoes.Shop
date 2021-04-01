using MaxShoes.Shop.Application.Models.UserModels;
using MediatR;
using System;

namespace MaxShoes.Shop.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand: IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = UserRoles.Employee;

        public bool IsEmailConfirmed { get; set; } = false;
        public Contact Contact { get; set; }
    }
}
