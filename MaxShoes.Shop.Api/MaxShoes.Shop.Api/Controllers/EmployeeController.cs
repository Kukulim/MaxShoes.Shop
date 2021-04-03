using MaxShoes.Shop.Application.Features.Employees.Commands.CreateEmployee;
using MaxShoes.Shop.Application.Features.Employees.Commands.EditEmployee;
using MaxShoes.Shop.Application.Features.Employees.Queries.GetEmployeeList;
using MaxShoes.Shop.Application.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getallemployee")]
        public async Task<ActionResult> GetEmployeesAsync()
        {
            var dtos = await mediator.Send(new GetEmployeeListQuery());
            return Ok(dtos);
        }

        [HttpPost("createemployee")]
        public async Task<ActionResult<string>> CreateEmployeeAsync([FromBody] CreateEmployeeCommand request)
        {
            var id = await mediator.Send(request);
            return Ok(id);
        }

        [HttpPost("editemployee")]
        public async Task<ActionResult> EditEmployeeAsync([FromBody] EditEmployeeCommand request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
