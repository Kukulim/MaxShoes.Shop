using AutoMapper;
using MaxShoes.Shop.Application.Features.Employees.Commands.CreateEmployee;
using MaxShoes.Shop.Application.Features.Employees.Queries.GetEmployeeList;
using MaxShoes.Shop.Application.Features.Notifications.Commands.CreateNotification;
using MaxShoes.Shop.Application.Features.Notifications.Queries.GetCurrentUserNotificationList;
using MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationList;
using MaxShoes.Shop.Application.Models.UserModels;
using MaxShoes.Shop.Domain.Entities;
using MaxShoes.Shop.Identity.Models.UserModels;

namespace MaxShoes.Shop.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notification, NotificationCreateVm>().ReverseMap();
            CreateMap<Notification, NotificationListVm>().ReverseMap();
            CreateMap<Notification, CurentUserNotificationListVm>().ReverseMap();
            CreateMap<Notification, NotificationCreateVm>().ReverseMap();
            CreateMap<Notification, CreateNotificationCommand>().ReverseMap();

            CreateMap<User, EmployeeListVm>().ReverseMap();
            CreateMap<User, CreateEmployeeCommand>().ReverseMap();

            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
