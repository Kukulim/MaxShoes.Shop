using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Application.Models.UserModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeListVm>>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;

        public GetEmployeeListQueryHandler(IMapper mapper, IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.employeeService = employeeService;
        }
        public async Task<List<EmployeeListVm>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var list = await employeeService.GetAllEmployeesAsync();

            return mapper.Map<List<EmployeeListVm>>(list);
        }
    }
}
