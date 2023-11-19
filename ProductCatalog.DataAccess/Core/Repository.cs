using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Behaviour;
using ProductCatalog.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.DataAccess.Core
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ProductCatalogContext _context;
        private readonly DbSet<T> _set;
        public Repository(ProductCatalogContext context)
        {
            this._context = context;
            this._set = context.Set<T>();
        }
        public async Task Add(T entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Find(int id)
        {
            return await _set.SingleAsync<T>(_ => _.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _set.AsQueryable<T>();
        }

        public IQueryable<T> GetPaginatedCollection<TKey>(Func<T, TKey> sortBy, Func<T, bool> filter, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
