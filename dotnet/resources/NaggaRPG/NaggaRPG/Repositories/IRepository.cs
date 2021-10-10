using NaggaRPG.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NaggaRPG.Repositories
{
    public interface IRepository<T> where T : IDbEntity
    {
        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<bool> Delete(T entity);

        Task<T> GetById(int id);
    }
}