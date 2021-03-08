using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Commands.DeleteNotification
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand>
    {
        private readonly IAsyncRepository<Notification> notificationsRepository;
        private readonly IMapper mapper;

        public DeleteNotificationCommandHandler(IAsyncRepository<Notification> notificationsRepository, IMapper mapper)
        {
            this.notificationsRepository = notificationsRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationToDelete = await notificationsRepository.GetByIdAsync(request.Id);
            await notificationsRepository.DeleteAsync(notificationToDelete);
            return Unit.Value;
        }
    }
}
