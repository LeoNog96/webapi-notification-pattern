using Mapster;
using MediatR;
using NotificationPattern.Application.Notifications;
using NotificationPattern.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationPattern.Application.Models.EntityNotification.Get.Query
{
    public class EntityNotificationQueryHandler : IRequestHandler<EntityNotificationQuery, EntityNotificationQueryResult>
    {
        private readonly IEntityNotificationRepository _entityNotificationRepository;
        private readonly NotificationContext _notificationContext;

        public EntityNotificationQueryHandler(IEntityNotificationRepository entityNotificationRepository, NotificationContext notificationContext)
        {
            _entityNotificationRepository = entityNotificationRepository;
            _notificationContext = notificationContext;
        }

        public async Task<EntityNotificationQueryResult> Handle(EntityNotificationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _entityNotificationRepository.Get(request.Id);
            
            if (entity == null)
            {
                _notificationContext.AddNotification("Falha ao Buscar Entidade", "Entidade não Existe!");
                _notificationContext.SetStatusCode((int)HttpStatusCode.NotFound);

                return null;
            }

            return entity.Adapt<EntityNotificationQueryResult>();
        }
    }
}
