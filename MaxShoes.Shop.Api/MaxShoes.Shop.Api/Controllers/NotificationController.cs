using MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationList;
using MaxShoes.Shop.Application.Features.Notifications.Queries.GetCurrentUserNotificationList;
using MaxShoes.Shop.Application.Models.UserModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //[Authorize(Roles = UserRoles.Employee)]
        [HttpGet("getall")]
        public async Task<ActionResult<NotificationListVm>> GetAllNotificationsAsync()
        {
            var dtos = await mediator.Send(new Application.Features.Notifications.Queries.GetNotificationList.GetCurrentUserNotificationListQuery());
            return Ok(dtos);
        }

        //[Authorize(Roles = UserRoles.Customer)]
        [HttpGet("getall/{id}")]
        public async Task<ActionResult<NotificationListVm>> GetAllCurrentUserNotificationsAsync(string id)
        {
            var getCategoriesListWithEventsQuery = new Application.Features.Notifications.Queries.GetCurrentUserNotificationList.GetCurrentUserNotificationListQuery() { CurrentUserId = id };

            var dtos = await mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(dtos);
        }
    }
}
