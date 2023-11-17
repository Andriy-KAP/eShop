using Microsoft.EntityFrameworkCore;
using ShopingCart.DataAccess.Bahaviour;
using ShopingCart.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.Core
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ShopingCartContext _context;
        private readonly DbSet<T> _set;
        public Repository(ShopingCartContext context)
        {
            this._context = context;
            this._set = context.Set<T>();
        }
        public async Task<T> Find(int id)
        {
            return await _set.SingleAsync<T>(_=>_.Id == id);
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
        public async Task Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public IQueryable<T> GetAll()
        {
            return _set.AsQueryable<T>();
        }
    }
}
