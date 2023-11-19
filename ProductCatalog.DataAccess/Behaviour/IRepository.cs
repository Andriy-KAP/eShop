using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.Behaviour
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Find(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetPaginatedCollection<TKey>(Func<T, TKey> sortBy, Func<T, bool> filter, int page, int pageSize);
    }
}
