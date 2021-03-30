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

        //[HttpPost("createemployee")]
        //public ActionResult CreateEmployee([FromBody] User request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    request.Password = BC.HashPassword(request.Password);
        //    request.Contact.UserId = request.Id;
        //    _userService.Create(request);
        //    _userService.Complete();
        //    return Ok();
        //}

        //[HttpPost("editemployee")]
        //public ActionResult EditEmployee([FromBody] User request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var editedEmployee = _userService.EditEmployee(request);
        //    _userService.Complete();
        //    return Ok(editedEmployee);
        //}
    }
}
