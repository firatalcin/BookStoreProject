using BookStore.DataAccess.Concrete.EntityFramework.Context;
using BookStore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public void Add(TEntity entity)
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var deletedEntity = context.Set<TEntity>().Find(id);
                deletedEntity.ModifiedDate = DateTime.Now;
                deletedEntity.Status = Entities.Enums.DataStatus.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (MyDbContext context = new MyDbContext())
            {
                return context.Set<TEntity>().Where(filter).Where(x => x.Status != Entities.Enums.DataStatus.Deleted).SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (MyDbContext context = new MyDbContext())
            {
                return filter == null ? 
                    context.Set<TEntity>().Where(x => x.Status != Entities.Enums.DataStatus.Deleted).ToList() : 
                    context.Set<TEntity>().Where(filter).Where(x=> x.Status != Entities.Enums.DataStatus.Deleted).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (MyDbContext context = new MyDbContext())
            {
                entity.ModifiedDate = DateTime.Now;
                entity.Status = Entities.Enums.DataStatus.Update;
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
