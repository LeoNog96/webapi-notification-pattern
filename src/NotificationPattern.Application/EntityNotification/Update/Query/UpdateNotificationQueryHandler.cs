using Mapster;
using MediatR;
using NotificationPattern.Application.Notifications;
using NotificationPattern.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationPattern.Application.EntityNotification.Update.Query
{
    public class UpdateNotificationQueryHandler : IRequestHandler<UpdateNotificationQuery, UpdateNotificationQueryResult>
    {
        private readonly IEntityNotificationRepository _entityNotificationRepository;
        private readonly NotificationContext _notificationContext;

        public UpdateNotificationQueryHandler(IEntityNotificationRepository entityNotificationRepository, NotificationContext notificationContext)
        {
            _entityNotificationRepository = entityNotificationRepository;
            _notificationContext = notificationContext;
        }

        public async Task<UpdateNotificationQueryResult> Handle(UpdateNotificationQuery request, CancellationToken cancellationToken)
        {
            if (request.Invalid)
            {
                _notificationContext.AddNotifications(request.ValidationResult);

                return null;
            }

            var entity = await _entityNotificationRepository.Update(request.Adapt<Domain.Model.EntityNotification>());

            if (entity == null)
            {
                _notificationContext.AddNotification("Falha ao Salvar Entidade", "Não foi possivel persistir os dados!");

                return null;
            }

            return entity.Adapt<UpdateNotificationQueryResult>();
        }
    }
}
