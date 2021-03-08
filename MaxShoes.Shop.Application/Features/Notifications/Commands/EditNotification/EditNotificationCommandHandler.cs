using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Commands.EditNotification
{
    public class EditNotificationCommandHandler : IRequestHandler<EditNotificationCommand, Notification>
    {
        private readonly IAsyncRepository<Notification> notificationsRepository;
        private readonly IMapper mapper;

        public EditNotificationCommandHandler(IAsyncRepository<Notification> notificationsRepository, IMapper mapper)
        {
            this.notificationsRepository = notificationsRepository;
            this.mapper = mapper;
        }
        public async Task<Notification> Handle(EditNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationToEdit = await notificationsRepository.GetByIdAsync(request.Id);
            notificationToEdit = await notificationsRepository.EditAsync(notificationToEdit);
            return notificationToEdit;
        }
    }
}
