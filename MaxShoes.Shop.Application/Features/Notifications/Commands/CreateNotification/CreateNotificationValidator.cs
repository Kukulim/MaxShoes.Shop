using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Features.Notifications.Commands.CreateNotification
{
    class CreateNotificationValidator:AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationValidator()
        {
            RuleFor(n => n.Title)
                .NotNull()
                .NotEmpty();
        }
    }
}
