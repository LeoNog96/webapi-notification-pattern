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

        public override Task<EntityNotification> Get(object id)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<EntityNotification>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<EntityNotification> Save(EntityNotification entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<EntityNotification>> SaveRange(IEnumerable<EntityNotification> entity)
        {
            throw new NotImplementedException();
        }

        public override Task Update(EntityNotification entity, object id)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateRange(IEnumerable<EntityNotification> entity)
        {
            throw new NotImplementedException();
        }
    }
}
