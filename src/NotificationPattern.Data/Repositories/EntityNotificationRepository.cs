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
            try
            {
                var entity = await _db.EntityNotifications.FindAsync(id);

                _db.Entry(entity).State = EntityState.Detached;

                return entity.Adapt<EntityNotification>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async override Task<IEnumerable<EntityNotification>> GetAll(int page, int qtd)
        {
            try
            {
                var entities = await _db.EntityNotifications
                                        .OrderBy(x => x.Id)
                                        .Skip(qtd * (page - 1))
                                        .Take(qtd)
                                        .AsNoTracking()
                                        .ToListAsync();

                return entities.Adapt<IEnumerable<EntityNotification>>();
            }
            catch(Exception)
            {
                return null;
            }            
        }

        public async override Task<EntityNotification> Save(EntityNotification entity)
        {
            try
            {
                var newEntity = entity.Adapt<EntityNotificationEntity>();

                _db.EntityNotifications.Add(newEntity);

                await _db.SaveChangesAsync();

                return newEntity.Adapt<EntityNotification>();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async override Task<IEnumerable<EntityNotification>> SaveRange(IEnumerable<EntityNotification> entity)
        {
            try
            {
                var newEntities = entity.Adapt<IEnumerable<EntityNotificationEntity>>();

                _db.EntityNotifications.AddRange(newEntities);

                await _db.SaveChangesAsync();

                return newEntities.Adapt<IEnumerable<EntityNotification>>();
            }
            catch (Exception)
            {
                return null;
            }
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
