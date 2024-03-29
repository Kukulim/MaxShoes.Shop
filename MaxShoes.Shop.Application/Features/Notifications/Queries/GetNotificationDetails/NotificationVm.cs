﻿using MaxShoes.Shop.Domain.Entities.StatusEnum;
using System;

namespace MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationDetails
{
    public class NotificationVm
    {
        public string Id { get; set; }

        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Response { get; set; }
        public DateTime SendedAt { get; set; }
        public Status Status { get; set; }

        public string FileUrl { get; set; }
    }
}
