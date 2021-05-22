using Mapster;
using MediatR;
using NotificationPattern.Application.Notifications;
using NotificationPattern.Domain.Repositories;
using NotificationPattern.Domain.Model;
using System.Threading;
using System.Threading.Tasks;

namespace NotificationPattern.Application.EntityNotification.Save.Query
{
    public class SaveEntityNotificationQueryHandler : IRequestHandler<SaveEntityNotificationQuery, SaveEntityNotificationQueryResult>
    {
        private readonly IEntityNotificationRepository _entityNotificationRepository;
        private readonly NotificationContext _notificationContext;

        public SaveEntityNotificationQueryHandler(IEntityNotificationRepository entityNotificationRepository, NotificationContext notificationContext)
        {
            _entityNotificationRepository = entityNotificationRepository;
            _notificationContext = notificationContext;
        }

        public async Task<SaveEntityNotificationQueryResult> Handle(SaveEntityNotificationQuery request, CancellationToken cancellationToken)
        {
            if (request.Invalid)
            {
                _notificationContext.AddNotifications(request.ValidationResult);

                return null;
            }

            var entity = await _entityNotificationRepository.Save(request.Adapt<Domain.Model.EntityNotification>());

            if (entity == null)
            {
                _notificationContext.AddNotification("Falha ao Salvar Entidade", "Não foi possivel persistir os dados!");

                return null;
            }

            return entity.Adapt<SaveEntityNotificationQueryResult>();
        }
    }
}
