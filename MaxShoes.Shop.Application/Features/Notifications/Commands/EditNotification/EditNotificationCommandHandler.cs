using AutoMapper;
using MaxShoes.Shop.Application.Contracts.Infrastructure;
using MaxShoes.Shop.Application.Contracts.Presistance;
using MaxShoes.Shop.Application.Exceptions;
using MaxShoes.Shop.Domain.Entities;
using MaxshoesBack.Services.UserServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaxShoes.Shop.Application.Features.Notifications.Commands.EditNotification
{
    public class EditNotificationCommandHandler : IRequestHandler<EditNotificationCommand, NotificationEditVm>
    {
        private readonly IAsyncRepository<Notification> notificationsRepository;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        private readonly IUserServices userService;

        public EditNotificationCommandHandler(IAsyncRepository<Notification> notificationsRepository, IMapper mapper, IEmailService emailService, IUserServices userService)
        {
            this.notificationsRepository = notificationsRepository;
            this.mapper = mapper;
            this.emailService = emailService;
            this.userService = userService;
        }
        public async Task<NotificationEditVm> Handle(EditNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationToEdit = await notificationsRepository.GetByIdAsync(request.Id);

            if (notificationToEdit==null)
            {
                throw new NotFoundException(nameof(Notification), request.Id);
            }
            notificationToEdit = await notificationsRepository.EditAsync(notificationToEdit);
            try
            {
                var CurrentUser =await  userService.GetUserAsync(request.UserId);
                await emailService.SendEmailAsync("email@gmail.com", request.Title, request.Description);
                await emailService.SendEmailAsync(CurrentUser.Email, "The notification status has changed", "<h1>Hello from Max Shoes</h1>" + $"<p> The notification that id ={request.Id} status has changed</p> <p>Please check your account on our site.</p>");
            }
            catch (Exception)
            {
               //mayge logg
            }
            return mapper.Map<NotificationEditVm>(notificationToEdit);
        }
    }
}
