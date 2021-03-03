using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Features.Events
{
    class GetNotificationListQuery: IRequest <List<NotificationVm>>
    {
    }
}
