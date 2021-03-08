using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Notification>
    {
        private readonly IAsyncRepository<Notification> notificationsRepository;
        private readonly IMapper mapper;

        public CreateNotificationCommandHandler(IAsyncRepository<Notification> notificationsRepository, IMapper mapper)
        {
            this.notificationsRepository = notificationsRepository;
            this.mapper = mapper;
        }

        public async Task<Notification> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = mapper.Map<Notification>(request);
            notification = await notificationsRepository.AddAsync(notification);
            return notification;
        }
    }
}
