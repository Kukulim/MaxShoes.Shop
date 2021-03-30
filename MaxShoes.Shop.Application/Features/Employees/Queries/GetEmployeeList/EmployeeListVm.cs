using MaxShoes.Shop.Application.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Features.Employees.Queries.GetEmployeeList
{
    class EmployeeListVm
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;
        public ContactDto Contact { get; set; }
    }
}
