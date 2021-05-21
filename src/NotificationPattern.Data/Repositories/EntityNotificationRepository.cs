using Mapster;
using Microsoft.EntityFrameworkCore;
using NotificationPattern.Data.Context;
using NotificationPattern.Data.Entities;
using NotificationPattern.Domain.Model;
using NotificationPattern.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Data.Repositories
{
    public class EntityNotificationRepository : BaseRepository<EntityNotification>, IEntityNotificationRepository
    {
        
        public EntityNotificationRepository(NotificationPatternContext db) : base(db) { }

        public async override Task Delete(long id)
        {
            var entity = await _db.EntityNotifications.FindAsync(id);

            _db.Entry(entity).State = EntityState.Detached;

            _db.EntityNotifications.Remove(entity);
            
            await _db.SaveChangesAsync();
        }

        public override Task DeleteRange(IEnumerable<EntityNotification> entity)
        {
            throw new NotImplementedException();
        }

        public async override Task<EntityNotification> Get(long id)
        {
            var entity = await _db.EntityNotifications.FindAsync(id);

            _db.Entry(entity).State = EntityState.Detached;

            return entity.Adapt<EntityNotification>();
        }

        public async override Task<IEnumerable<EntityNotification>> GetAll()
        {
            var entities = await _db.EntityNotifications.ToListAsync();

            return entities.Adapt<IEnumerable<EntityNotification>>();
        }

        public async override Task<EntityNotification> Save(EntityNotification entity)
        {
            var newEntity = entity.Adapt<EntityNotificationEntity>();
            
            _db.EntityNotifications.Add(newEntity);

            await _db.SaveChangesAsync();

            return newEntity.Adapt<EntityNotification>();
        }

        public async override Task<IEnumerable<EntityNotification>> SaveRange(IEnumerable<EntityNotification> entity)
        {
            var newEntities = entity.Adapt<IEnumerable<EntityNotificationEntity>>();

            _db.EntityNotifications.AddRange(newEntities);

            await _db.SaveChangesAsync();

            return newEntities.Adapt<IEnumerable<EntityNotification>>();
        }

        public async override Task Update(EntityNotification entity)
        {
            var newEntity = entity.Adapt<EntityNotificationEntity>();

            _db.EntityNotifications.Update(newEntity);

            await _db.SaveChangesAsync();
        }

        public async override Task UpdateRange(IEnumerable<EntityNotification> entity)
        {
            var newEntities = entity.Adapt<IEnumerable<EntityNotificationEntity>>();

            _db.EntityNotifications.UpdateRange(newEntities);

            await _db.SaveChangesAsync();
        }
    }
}
