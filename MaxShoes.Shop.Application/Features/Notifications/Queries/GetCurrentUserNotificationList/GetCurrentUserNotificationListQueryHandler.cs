using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Application.Exceptions;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Queries.GetCurrentUserNotificationList
{
    class GetCurrentUserNotificationListQueryHandler : IRequestHandler<GetCurrentUserNotificationListQuery, List<CurentUserNotificationListVm>>
    {
        private readonly IMapper _mapper;
        private readonly INotificationRepository _notificationsRepository;

        public GetCurrentUserNotificationListQueryHandler(INotificationRepository notificationsRepository, IMapper mapper)
        {
            _notificationsRepository = notificationsRepository;
            _mapper = mapper;
        }

        public async Task<List<CurentUserNotificationListVm>> Handle(GetCurrentUserNotificationListQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationsRepository.GetAllCurrentUserAsync(request.CurrentUserId);

            if (notifications==null)
            {
                throw new NotFoundException(nameof(Notification), request.CurrentUserId);
            }
            return _mapper.Map <List<CurentUserNotificationListVm>>(notifications);
        }

    }
}
