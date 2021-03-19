using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Application.Exceptions;
using MaxShoes.Shop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, NotificationCreateVm>
    {
        private readonly IAsyncRepository<Notification> notificationsRepository;
        private readonly IMapper mapper;

        public CreateNotificationCommandHandler(IAsyncRepository<Notification> notificationsRepository, IMapper mapper)
        {
            this.notificationsRepository = notificationsRepository;
            this.mapper = mapper;
        }

        public async Task<NotificationCreateVm> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateNotificationValidator();
            var validatorResult = validator.ValidateAsync(request);

            if (validatorResult.Result.Errors.Count>0)
            {
                throw new ValidationException(validatorResult.Result);
            }

            var notification = mapper.Map<Notification>(request);

            notification = await notificationsRepository.AddAsync(notification);

            return mapper.Map<NotificationCreateVm>(notification);
        }
    }
}
