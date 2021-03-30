using MediatR;
using System.Collections.Generic;

namespace MaxShoes.Shop.Application.Features.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery: IRequest<List<EmployeeListVm>>
    {
    }
}
