using DataAccess.Repositories;
using Entities.Model;

namespace DataAccess.Abstract.EntityFramework
{
    public interface IAuthorDal : IGenericRepository<Author>
    {
    }
}