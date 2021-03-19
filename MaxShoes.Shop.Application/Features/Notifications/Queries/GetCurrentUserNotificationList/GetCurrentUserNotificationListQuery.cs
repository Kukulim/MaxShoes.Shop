using MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationList;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Features.Notifications.Queries.GetCurrentUserNotificationList
{
    public class GetCurrentUserNotificationListQuery : IRequest<List<CurentUserNotificationListVm>>
    {
        public string CurrentUserId { get; set; }
    }
}
