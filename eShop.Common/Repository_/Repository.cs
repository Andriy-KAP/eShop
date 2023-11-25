using eShop.Common.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Common.Repository_
{
    public class Repository<T,TContext> : IRepository<T> where TContext : DbContext where T : class, IEntity
    {
        private readonly TContext _context;
        private readonly DbSet<T> _set;

        public Repository(TContext context)
        {
            _context = context;
            _set = _context.Set<T>();
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

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.Entry<T>(entity).State= EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
