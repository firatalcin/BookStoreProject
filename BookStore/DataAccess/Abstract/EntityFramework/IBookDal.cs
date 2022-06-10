using DataAccess.Repositories;
using Entities.Model;

namespace DataAccess.Abstract.EntityFramework
{
    public interface IBookDal : IGenericRepository<Book>
    {
    }
}