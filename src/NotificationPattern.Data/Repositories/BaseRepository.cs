using Microsoft.EntityFrameworkCore;
using NotificationPattern.Data.Context;
using NotificationPattern.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly NotificationPatternContext _db;

        public BaseRepository(NotificationPatternContext db)
        {
            _db = db;
        }

        public abstract Task<IEnumerable<T>> GetAll();

        public abstract Task<T> Get(long id);

        public abstract Task<T> Save(T entity);

        public abstract Task<IEnumerable<T>> SaveRange(IEnumerable<T> entity);

        public abstract Task Update(T entity);

        public abstract Task UpdateRange(IEnumerable<T> entity);

        public abstract Task Delete(long id);

        public abstract Task DeleteRange(IEnumerable<T> entity);
    }
}
