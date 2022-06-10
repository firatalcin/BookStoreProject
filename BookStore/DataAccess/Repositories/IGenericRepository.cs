using Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}