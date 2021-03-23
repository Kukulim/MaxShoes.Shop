using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Application.Exceptions;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Queries.GetNotificationDetails
{
    class GetNotificationDetailsQueryHandler : IRequestHandler<GetNotificationDetailsQuery, NotificationVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Notification> _notificationsRepository;

        public GetNotificationDetailsQueryHandler(IAsyncRepository<Notification> notificationsRepository, IMapper mapper)
        {
            _notificationsRepository = notificationsRepository;
            _mapper = mapper;
        }

        public async Task<NotificationVm> Handle(GetNotificationDetailsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationsRepository.GetByIdAsync(request.NotificationId.ToString());
            if (notifications == null)
            {
                throw new NotFoundException(nameof(Notification), request.NotificationId);
            }
            return _mapper.Map<NotificationVm>(notifications);
        }
    }
}
