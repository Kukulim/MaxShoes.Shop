using AutoMapper;
using MaxShoes.Shop.Application.Features.Events;
using MaxShoes.Shop.Domain.Entities;

namespace MaxShoes.Shop.Application.Features.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Notification, NotificationVm>().ReverseMap();
        }
    }
}
