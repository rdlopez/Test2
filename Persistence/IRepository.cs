using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IRepository<T> : IOrderedQueryable<T>
    {
        Task Delete(T entity);
        IList<T> GetAll(bool useCache = true, bool IncludeDisabled = false);
        Task Put(IEnumerable<T> entities);
        Task Put(T entity);
        Task Update(T entity, Func<T, T, bool> mergeNewEntity = null);
        Task Update(IEnumerable<T> entities, Func<T, T, bool> mergeNewEntity = null);
    }
}