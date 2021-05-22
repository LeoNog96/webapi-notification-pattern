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

namespace NotificationPattern.Application.EntityNotification.Get.Query
{
    public class GetEntityNotificationQueryHandler : IRequestHandler<GetEntityNotificationQuery, GetEntityNotificationQueryResult>
    {
        private readonly IEntityNotificationRepository _entityNotificationRepository;
        private readonly NotificationContext _notificationContext;

        public GetEntityNotificationQueryHandler(IEntityNotificationRepository entityNotificationRepository, NotificationContext notificationContext)
        {
            _entityNotificationRepository = entityNotificationRepository;
            _notificationContext = notificationContext;
        }

        public async Task<GetEntityNotificationQueryResult> Handle(GetEntityNotificationQuery request, CancellationToken cancellationToken)
        {
            var entity = await _entityNotificationRepository.Get(request.Id);
            
            if (entity == null)
            {
                _notificationContext.AddNotification("Falha ao Buscar Entidade", "Entidade não Existe!");
                _notificationContext.SetStatusCode((int)HttpStatusCode.NotFound);

                return null;
            }

            return entity.Adapt<GetEntityNotificationQueryResult>();
        }
    }
}
