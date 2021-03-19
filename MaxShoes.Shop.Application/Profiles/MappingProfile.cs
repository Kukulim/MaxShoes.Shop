using AutoMapper;
using MaxShoes.Shop.Application.Features.Notifications.Commands.CreateNotification;
using MaxShoes.Shop.Application.Features.Notifications.Queries.GetCurrentUserNotificationList;
using MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationList;
using MaxShoes.Shop.Domain.Entities;

namespace MaxShoes.Shop.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notification, NotificationVm>().ReverseMap();
            CreateMap<Notification, NotificationListVm>().ReverseMap();
            CreateMap<Notification, CurentUserNotificationListVm>().ReverseMap();
        }
    }
}
