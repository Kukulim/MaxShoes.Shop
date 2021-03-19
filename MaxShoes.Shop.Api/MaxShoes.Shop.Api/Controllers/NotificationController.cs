using MaxShoes.Shop.Application.Features.Notifications.Commands.CreateNotification;
using MaxShoes.Shop.Application.Features.Notifications.Commands.EditNotification;
using MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationList;
using MaxShoes.Shop.Application.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator mediator;

        public NotificationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = UserRoles.Employee)]
        [HttpGet("getall")]
        public async Task<ActionResult<NotificationListVm>> GetAllNotificationsAsync()
        {
            var dtos = await mediator.Send(new GetCurrentUserNotificationListQuery());
            return Ok(dtos);
        }

        [Authorize(Roles = UserRoles.Customer)]
        [HttpGet("getall/{id}")]
        public async Task<ActionResult<NotificationListVm>> GetAllCurrentUserNotificationsAsync(string id)
        {
            var getCategoriesListWithEventsQuery = new Application.Features.Notifications.Queries.GetCurrentUserNotificationList.GetCurrentUserNotificationListQuery() { CurrentUserId = id };

            var dtos = await mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(dtos);
        }

        [Authorize(Roles = UserRoles.Customer)]
        [HttpPost("createnotification")]
        public async Task<ActionResult<NotificationCreateVm>> Create([FromBody] CreateNotificationCommand createNotificationCommand)
        {
            var notificationRespoonse = await mediator.Send(createNotificationCommand);
            return Ok(notificationRespoonse);
        }

        [HttpPost("editnotification")]
        [Authorize(Roles = UserRoles.Employee)]
        public async Task<ActionResult> EditNotification([FromBody] EditNotificationCommand editNotificationCommand)
        {
            var notificationRespoonse = await mediator.Send(editNotificationCommand);
            return Ok(notificationRespoonse);
        }
    }
}