using MaxShoes.Shop.Application.Contracts.Infrastructure;
using MaxShoes.Shop.Application.Features.Notifications.Commands.CreateNotification;
using MaxShoes.Shop.Application.Features.Notifications.Commands.EditNotification;
using MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationList;
using MaxShoes.Shop.Application.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IFileService fileService;

        public NotificationController(IMediator mediator,IFileService fileService)
        {
            this.mediator = mediator;
            this.fileService = fileService;
        }

        [Authorize(Roles = UserRoles.Employee)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("getall")]
        public async Task<ActionResult<NotificationListVm>> GetAllNotificationsAsync()
        {
            var dtos = await mediator.Send(new GetCurrentUserNotificationListQuery());
            return Ok(dtos);
        }

        [Authorize(Roles = UserRoles.Customer)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("getall/{id}")]
        public async Task<ActionResult<NotificationListVm>> GetAllCurrentUserNotificationsAsync(string id)
        {
            var getCategoriesListWithEventsQuery = new Application.Features.Notifications.Queries.GetCurrentUserNotificationList.GetCurrentUserNotificationListQuery() { CurrentUserId = id };

            var dtos = await mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(dtos);
        }

        [Authorize(Roles = UserRoles.Customer)]
        [HttpPost("createnotification")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NotificationCreateVm>> Create([FromBody] CreateNotificationCommand createNotificationCommand)
        {
            var notificationRespoonse = await mediator.Send(createNotificationCommand);
            return Ok(notificationRespoonse);
        }

        [HttpPost("editnotification")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Authorize(Roles = UserRoles.Employee)]
        public async Task<ActionResult> EditNotification([FromBody] EditNotificationCommand editNotificationCommand)
        {
            var notificationRespoonse = await mediator.Send(editNotificationCommand);
            return Ok(notificationRespoonse);
        }

        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(
         IFormFile file,
         CancellationToken cancellationToken)
        {
            if (fileService.CheckIfSuportedFile(file))
            {
                await fileService.WriteFile(file);
            }
            else
            {
                return BadRequest(new { message = "Invalid file extension" });
            }

            return Ok();
        }

        [HttpGet]
        [Route("download")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Download([FromQuery] string file)
        {
            var memory = await fileService.DownloadFile(file);
            return File(memory, "text/plain", file);
        }
    }
}