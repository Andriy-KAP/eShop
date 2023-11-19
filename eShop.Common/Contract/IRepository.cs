using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Common.Contract
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Find(int id);
        IQueryable<T> GetAll();
    }
}
