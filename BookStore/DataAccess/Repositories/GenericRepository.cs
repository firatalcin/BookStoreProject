using DataAccess.Contexts;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly BookStoreDbContext _context;

        public GenericRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? _context.Set<T>().AsQueryable() : _context.Set<T>().Where(filter).AsQueryable();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}