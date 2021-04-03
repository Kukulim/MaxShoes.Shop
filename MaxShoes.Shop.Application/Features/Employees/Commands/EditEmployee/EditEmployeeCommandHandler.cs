using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Identity.Models.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Employees.Commands.EditEmployee
{
    class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;

        public EditEmployeeCommandHandler(IMapper mapper, IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.employeeService = employeeService;
        }

        async Task<Unit> IRequestHandler<EditEmployeeCommand, Unit>.Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<User>(request);
            await employeeService.UpdateAsync(employee);
            return Unit.Value;
        }
    }
}
