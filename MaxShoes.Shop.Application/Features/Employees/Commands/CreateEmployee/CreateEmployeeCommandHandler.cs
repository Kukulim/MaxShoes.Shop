using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Identity.Models.UserModels;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, string>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;
        private readonly ILogger<CreateEmployeeCommandHandler> logger;

        public CreateEmployeeCommandHandler(IMapper mapper, IEmployeeService employeeService, ILogger<CreateEmployeeCommandHandler> logger)
        {
            this.mapper = mapper;
            this.employeeService = employeeService;
            this.logger = logger;
        }
        public async Task<string> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = mapper.Map<User>(request);

            var EmployeeId = await employeeService.AddAsync(employee);
            return EmployeeId;
        }
    }
}
