using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Features.Events
{
    class GetNotificationDetailsQuery: IRequest <NotificationVm>
    {
        public Guid NotificationId { get; set; }
    }
}
