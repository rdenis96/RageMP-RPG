using Microsoft.EntityFrameworkCore;
using NaggaRPG.EntityContexts;
using NaggaRPG.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaggaRPG.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IDbEntity
    {
        public abstract Task<T> Create(T entity);

        public abstract Task<IEnumerable<T>> GetAll();

        public abstract Task<T> GetById(int id);

        public async Task<bool> Delete(T entity)
        {
            bool changesSaved = false;
            using (var context = new MysqlContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                entity.IsDeleted = true;
                changesSaved = await context.SaveChangesAsync() > 0;
            }

            return changesSaved;
        }

        public async Task<T> Update(T entity)
        {
            bool changesSaved = false;
            using (var context = new MysqlContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                changesSaved = await context.SaveChangesAsync() > 0;
            }
            return changesSaved ? entity : default;
        }
    }
}