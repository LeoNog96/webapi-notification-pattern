using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.EntityNotification.Validators
{
    public class EntityNotificationValidator : AbstractValidator<BaseWriteEntityNotificationRequest>
    {
        public EntityNotificationValidator()
        {
            RuleFor(a => a.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id Invalido");

            RuleFor(a => a.Description)
                .Empty()
                .WithMessage("Descrição nao pode ser vazia");
        }
    }
}
