using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQueryHandler : IRequestHandler<GetCurrentUserNotificationListQuery, List<NotificationListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Notification> _notificationsRepository;

        public GetNotificationListQueryHandler(IMapper mapper, IAsyncRepository<Notification> notificationsRepository)
        {
            _mapper = mapper;
            _notificationsRepository = notificationsRepository;
        }


        public async Task<List<NotificationListVm>> Handle(GetCurrentUserNotificationListQuery request, CancellationToken cancellationToken)
        {
            var allNotifications = await _notificationsRepository.GetAllAsync();
            return _mapper.Map<List<NotificationListVm>>(allNotifications);
        }
    }
}
