using MaxShoes.Shop.Domain.Common;
using MaxShoes.Shop.Domain.Entities.StatusEnum;
using System;

namespace MaxShoes.Shop.Domain.Entities
{
    public class Notification : AuditableEntity

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