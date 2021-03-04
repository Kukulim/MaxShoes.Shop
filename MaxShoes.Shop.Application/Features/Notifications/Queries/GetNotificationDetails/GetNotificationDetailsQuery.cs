using MediatR;
using System;

namespace MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationDetails
{
    internal class GetNotificationDetailsQuery : IRequest<NotificationVm>
    {
        public Guid NotificationId { get; set; }
    }
}