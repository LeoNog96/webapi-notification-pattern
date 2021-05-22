using Mapster;
using NotificationPattern.Application.Models.EntityNotification.Requests;
using NotificationPattern.Application.Models.EntityNotification.Responses;
using NotificationPattern.Application.Services;
using NotificationPattern.Domain.Model;
using NotificationPattern.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Application.Impl.Services
{
    public class EntityNotificationService : IEntityNotificationService
    {
        private readonly IEntityNotificationRepository _entityNotificationRepository;

        public EntityNotificationService(IEntityNotificationRepository entityNotificationRepository)
        {
            _entityNotificationRepository = entityNotificationRepository;
        }

        public async Task Delete(long id)
        {
            try
            {
                await _entityNotificationRepository.Delete(id);
            }
            catch (Exception) { }
        }

        public async Task<EntityNotificationResponse> Get(long id)
        {
            var entityNotification = await _entityNotificationRepository.Get(id);

            if (entityNotification == null)
            {

            }

            return entityNotification.Adapt<EntityNotificationResponse>();
        }

        public async Task<IEnumerable<EntityNotificationResponse>> GetAll(int page, int qtd)
        {
            var entityNotifications = await _entityNotificationRepository.GetAll(page, qtd);

            if (entityNotifications == null)
            {

            }

            return entityNotifications.Adapt<IEnumerable<EntityNotificationResponse>>();
        }

        public async Task<EntityNotificationResponse> Save(EntityNotificationRequest entityNotificationRequest)
        {
            var entityNotification = await _entityNotificationRepository.Save(entityNotificationRequest.Adapt<EntityNotification>());

            if (entityNotification == null)
            {

            }

            return entityNotification.Adapt<EntityNotificationResponse>();
        }

        public async Task Update(EntityNotificationRequest entityNotificationRequest)
        {
            try
            {
                await _entityNotificationRepository.Update(entityNotificationRequest.Adapt<EntityNotification>());
            }
            catch (Exception) { }
        }
    }
}
