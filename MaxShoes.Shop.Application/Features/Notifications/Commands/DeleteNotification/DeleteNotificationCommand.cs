using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Features.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommand:IRequest
    {
        public string Id { get; set; }
    }
}
